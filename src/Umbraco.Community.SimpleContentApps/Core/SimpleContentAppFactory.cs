using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.Dashboards;
using Umbraco.Cms.Core.Hosting;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Models.Entities;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Security;
using Umbraco.Community.SimpleContentApps.Core.Extensions;
using Umbraco.Extensions;

namespace Umbraco.Community.SimpleContentApps.Core;

public class SimpleContentAppFactory<T> : IContentAppFactory where T : class, ISimpleContentApp
{
    private readonly IBackOfficeSecurityAccessor _backoffice;
    private readonly GlobalSettings _options;
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly T _contentApp;

    public SimpleContentAppFactory(
        IServiceProvider serviceProvider,
        IOptions<GlobalSettings> options,
        IHostingEnvironment hostingEnvironment,
        IBackOfficeSecurityAccessor backoffice)
    {
        _hostingEnvironment = hostingEnvironment;
        _backoffice = backoffice;
        _options = options.Value;
        _contentApp = ActivatorUtilities.CreateInstance<T>(serviceProvider);
    }

    public ContentApp? GetContentAppFor(object source, IEnumerable<IReadOnlyUserGroup> userGroups)
    {
        var input = source as IUmbracoEntity;
        var id = 0;
        switch (input)
        {
            case IMember member:
                if (!_contentApp.ShowInMembers)
                {
                    return null;
                }

                id = member.Id;
                break;
            case IMedia media:
                if (!_contentApp.ShowInMedia)
                {
                    return null;
                }

                id = media.Id;
                break;
            case IContent content:
                if (!_contentApp.ShowInContent)
                {
                    return null;
                }

                id = content.Id;
                break;
            case IContentType contentType:
                if (!_contentApp.ShowInContentType)
                {
                    return null;
                }

                id = contentType.Id;
                break;
            default:
                throw new InvalidCastException("Type is not supported " + source.GetType().Name);
        }

        var rules = _contentApp.Rules;
        if (rules.Any())
        {
            var userGroupsList = userGroups.ToList();
            var sections = userGroupsList.SelectMany(x => x.AllowedSections).ToList();
            var groups = userGroupsList.Select(x => x.Alias).ToList();

            var denied = rules.Where(x => x.Type == AccessRuleType.Deny).ToList();
            var allowGroups = rules.Where(x => x.Type == AccessRuleType.Grant).ToList();
            var allowSections = rules.Where(x => x.Type == AccessRuleType.GrantBySection).ToList();

            if (denied.Any(x => groups.Contains(x.Value)))
            {
                return null;
            }

            var alowByGroup = true;
            var alowBySection = true;
            if (allowGroups.Any())
            {
                alowByGroup = allowGroups.Any(x => groups.Contains(x.Value));
            }

            if (allowSections.Any())
            {
                alowBySection = allowSections.Any(x => sections.Contains(x.Value));
            }

            if (!alowBySection || !alowByGroup)
            {
                return null;
            }
        }

        var alias = _contentApp.Alias();
        var url = $"/{_options.GetSimpleContentRenderUrl(_hostingEnvironment)}/{alias}/{id}";

        var language = _backoffice.BackOfficeSecurity?.CurrentUser?.Language;
        var name = _contentApp.Name;
        if (!language.IsNullOrWhiteSpace())
        {
            name = _contentApp.CultureName(language).IfNullOrWhiteSpace(_contentApp.Name);
        }

        if (!_contentApp.ShouldShow(input))
        {
            return null;
        }

        return new ContentApp
        {
            Name = name,
            Alias = alias,
            Weight = _contentApp.Weight,
            Icon = _contentApp.Icon,
            View = url,
            Active = false,
            Badge = _contentApp.Badge
        };
    }
}