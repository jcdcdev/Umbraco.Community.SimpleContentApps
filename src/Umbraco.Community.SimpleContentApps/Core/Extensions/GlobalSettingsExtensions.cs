using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.Hosting;
using Umbraco.Community.SimpleContentApps.Web;
using Umbraco.Extensions;

namespace Umbraco.Community.SimpleContentApps.Core.Extensions;

public static class GlobalSettingsExtensions
{
    public static string GetSimpleContentRenderUrl(this GlobalSettings settings, IHostingEnvironment hostingEnvironment)
    {
        var backofficeArea = Cms.Core.Constants.Web.Mvc.BackOfficePathSegment;
        var area = Constants.Area;
        var name = area;
        var rootSegment = $"{settings.GetUmbracoMvcArea(hostingEnvironment)}/{backofficeArea}";
        return $"{rootSegment}/{area}/{nameof(SimpleContentAppController).TrimEnd("Controller")}/render";
    }
}
