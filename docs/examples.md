## Quick Start

### Register ContentApp

```csharp
using Umbraco.Cms.Core.Dashboards;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Community.SimpleContentApps.Core;

namespace Umbraco.Community.SimpleContentApps.TestSite;

public class BasicContentApp : ISimpleContentApp
{
    public string Icon => Cms.Core.Constants.Icons.Content;
    public bool ShowInContent => true;
    public bool ShowInContentType => false;
    public bool ShowInMedia => false;
    public bool ShowInMembers => false;
    public IAccessRule[] Rules => new[] { SimpleAccessRule.AllowAdminGroup };
    public int Weight => 0;
    public string Name => "Basic Content App";
    public string? CultureName(string? currentUiCulture) => Name;
    public ContentAppBadge? Badge => ContentAppBadges.None;
}
```

### Create View

- Your view **must** go in `/Views/ContentApps`
- You view **must** be the name of your C# class (without `ContentApp`)
  - For example: `BasicContentApp.cs` => `/Views/ContentApps/Basic.cshtml`

```csharp
@inherits Umbraco.Community.SimpleContentApps.Web.ContentAppViewPage

<h1>Hello Umbraco</h1>
<p>My ContentApp alias is: @Model.ContentApp.Alias()</p>
```

## View Component Example

- Your View Component should match the name of your C# class plus `ViewComponent.cs`
  - For example: `BasicContentApp.cs` => `BasicContentAppViewComponent.cs`
- Your View Component **must** inherit either:
  - `SimpleContentAppViewComponent`
  - `SimpleContentAppAsyncViewComponent`

```csharp
public class BasicContentAppViewComponent : SimpleContentAppAsyncViewComponent
{
    public override Task<IViewComponentResult> InvokeAsync(SimpleContentAppModel model)
    {
        // Complex business logic
        var viewModel = await _service.CreateViewModel(model);
        // ...
        return View("~/Views/MyPath/MyView.cshtml", viewModel);
    }
}
```