using System.Reflection;

namespace Umbraco.Community.SimpleContentApps.Core;

public static class Constants
{
    public const string Area = "SimpleContentApps";

    public static string ExampleViewComponent(string name) =>
        $@"using Microsoft.AspNetCore.Mvc;
using Umbraco.Community.SimpleContentApps.Web;

namespace {_nameSpace}.Views.Components;

public class {name}ViewComponent : SimpleContentAppViewComponent
{{
    public override IViewComponentResult Invoke(SimpleContentAppModel model)
    {{
        return Content($""Hello {{model.ContentApp.Alias()}}"");
    }}
}}";

    public static string ExampleView =
        @"@using Umbraco.Community.SimpleContentApps.Core.Extensions
@inherits Umbraco.Community.SimpleContentApps.Web.SimpleContentAppViewPage

<h1>Hello Umbraco</h1>
<p>My ContentApp is: @Model.ContentApp.Alias()</p>";

    private static readonly string _nameSpace = Assembly.GetEntryAssembly()?.GetName()?.Name ?? "YourNamespace";
}
