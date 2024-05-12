using jcdcdev.Umbraco.Core.AccessRule;
using jcdcdev.Umbraco.Core.ContentApp;
using Umbraco.Cms.Core.Dashboards;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Models.Entities;
using Umbraco.Community.SimpleContentApps.Core;

namespace TestSite.Thirteen.ContentApps;

public class RootNodeContentApp : ISimpleContentApp
{
    public string Icon => Umbraco.Cms.Core.Constants.Icons.Macro;
    public bool ShowInContent => true;
    public bool ShowInContentType => true;
    public bool ShowInMedia => true;
    public bool ShowInMembers => true;
    public IAccessRule[] Rules => [SimpleAccessRule.AllowAdminGroup];
    public int Weight => -10;
    public string Name => "Root Node";
    public string? CultureName(string? currentUiCulture) => Name;
    public ContentAppBadge? Badge => ContentAppBadges.Alert(123);

    public bool ShouldShow(IUmbracoEntity source) => source.Level == 1;
}
