using jcdcdev.Umbraco.Core.AccessRule;
using jcdcdev.Umbraco.Core.ContentApp;
using Umbraco.Cms.Core.Dashboards;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Community.SimpleContentApps.Core;

namespace TestSite.Ten.ContentApps;

public class ExampleContentApp : ISimpleContentApp
{
    public string Icon => Umbraco.Cms.Core.Constants.Icons.Packages;
    public bool ShowInContent => true;
    public bool ShowInContentType => false;
    public bool ShowInMedia => false;
    public bool ShowInMembers => false;
    public IAccessRule[] Rules => new[] { SimpleAccessRule.AllowAdminGroup };
    public int Weight => 0;
    public string Name => "Example Content App";
    public string? CultureName(string? currentUiCulture) => Name;
    public ContentAppBadge? Badge => ContentAppBadges.Warning(2);
}
