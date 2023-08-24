using Microsoft.AspNetCore.Mvc;

namespace Umbraco.Community.SimpleContentApps.Web;

public abstract class SimpleContentAppViewComponent : ViewComponent
{
    public abstract IViewComponentResult Invoke(SimpleContentAppModel model);
}
