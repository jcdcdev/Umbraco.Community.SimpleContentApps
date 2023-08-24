using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Web.Common.Authorization;
using Umbraco.Cms.Web.Common.Filters;
using Umbraco.Community.SimpleContentApps.Core;
using Umbraco.Community.SimpleContentApps.Core.Extensions;
using Umbraco.Extensions;

namespace Umbraco.Community.SimpleContentApps.Web;

[Authorize(Policy = AuthorizationPolicies.BackOfficeAccess)]
[DisableBrowserCache]
[Area(Constants.Area)]
public class SimpleContentAppController : Controller
{
    private readonly ICompositeViewEngine _viewEngine;
    private readonly ILogger _logger;
    private readonly IViewComponentDescriptorProvider _viewComponentDescriptorProvider;
    private readonly IAppPolicyCache _runtimeCache;
    private readonly SimpleContentAppCollection _collection;

    public SimpleContentAppController(
        ICompositeViewEngine viewEngine,
        ILogger<SimpleContentAppController> logger,
        IViewComponentDescriptorProvider viewComponentDescriptorProvider,
        AppCaches appCaches, SimpleContentAppCollection collection)
    {
        _viewEngine = viewEngine;
        _logger = logger;
        _viewComponentDescriptorProvider = viewComponentDescriptorProvider;
        _collection = collection;
        _runtimeCache = appCaches.RuntimeCache;
    }

    public IActionResult Render(string contentApp, int id)
    {
        var app = _collection.FirstOrDefault(x => x.Alias() == contentApp);
        if (app == null)
        {
            _logger.LogWarning("Failed to find ContentApp {ContentAppAlias}", contentApp);
            return Ok($"Unable to find Dashboard {contentApp}");
        }

        var path = $"~/Views/ContentApps/{contentApp}.cshtml";
        var model = new SimpleContentAppModel(app, id);
        var result = _viewEngine.GetView(null, path, false);
        if (result.Success)
        {
            return PartialView(result.ViewName, model);
        }

        var viewComponentName = $"{contentApp.ToFirstUpperInvariant()}ViewComponent";
        if (ViewComponentExists(viewComponentName))
        {
            return ViewComponent(viewComponentName, new { Model = model });
        }

        return PartialView("~/Views/ContentApps/ViewNotFound.cshtml", model);
    }

    private bool ViewComponentExists(string viewComponentName)
    {
        return _runtimeCache.GetCacheItem(viewComponentName, () =>
        {
            var viewComponentDescriptors = _viewComponentDescriptorProvider.GetViewComponents();
            return viewComponentDescriptors.Any(vc => vc.ShortName == viewComponentName);
        });
    }
}
