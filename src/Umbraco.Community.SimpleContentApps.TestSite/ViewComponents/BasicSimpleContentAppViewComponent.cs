using Microsoft.AspNetCore.Mvc;
using Umbraco.Community.SimpleContentApps.Web;

namespace Umbraco.Community.SimpleContentApps.TestSite.ViewComponents;

public class ExampleContentAppViewComponent : SimpleContentAppViewComponent
{
    public override IViewComponentResult Invoke(SimpleContentAppModel model)
    {
        var html = $"Hello, my Content App is called: {model.ContentApp.Name}";
        return Content(html);
    }
}
