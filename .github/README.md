# Umbraco.Community.SimpleContentApps

[![Downloads](https://img.shields.io/nuget/dt/Umbraco.Community.SimpleContentApps?color=cc9900)](https://www.nuget.org/packages/Umbraco.Community.SimpleContentApps/)
[![NuGet](https://img.shields.io/nuget/vpre/Umbraco.Community.SimpleContentApps?color=0273B3)](https://www.nuget.org/packages/Umbraco.Community.SimpleContentApps)
[![GitHub license](https://img.shields.io/github/license/jcdcdev/Umbraco.Community.SimpleContentApps?color=8AB803)](../LICENSE)

This packages aims to help developers quickly put together Umbraco ContentApps using C# only.

- Simplifies C# based ContentApp creation
- Supports both Views & View Components
- No package.manifest or lang/lang.xml files required!
- Variant support (culture specific names)
- Easy to define Access Rules

<img alt="Basic ContentApp in the Umbraco Office" src="https://raw.githubusercontent.com/jcdcdev/Umbraco.Community.SimpleContentApps/main/docs/screenshot.png" />

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
@using Umbraco.Community.SimpleContentApps.Core.Extensions
@inherits Umbraco.Community.SimpleContentApps.Web.SimpleContentAppViewPage

<h1>Hello Umbraco</h1>
<p>My ContentApp alias is: @Model.ContentApp.Alias()</p>
```

### More Examples

[docs/examples.md](https://github.com/jcdcdev/Umbraco.Community.SimpleContentApps/blob/dev/docs/examples.md)

## Contributing

Contributions to this package are most welcome! Please read the [Contributing Guidelines](CONTRIBUTING.md).

## Acknowledgments (thanks!)

- LottePitcher - [opinionated-package-starter](https://github.com/LottePitcher/opinionated-package-starter)