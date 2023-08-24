using Microsoft.AspNetCore.Mvc;

namespace Umbraco.Community.SimpleContentApps.Web;

public abstract class SimpleContentAppAsyncViewComponent : ViewComponent
{
    public abstract Task<IViewComponentResult> InvokeAsync(SimpleContentAppModel model);
}
