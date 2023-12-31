# Umbraco.Community.SimpleContentApps

[![Umbraco Version](https://img.shields.io/badge/Umbraco-10.4+-%233544B1?style=flat&logo=umbraco)](https://umbraco.com/products/umbraco-cms/)
[![NuGet](https://img.shields.io/nuget/vpre/Umbraco.Community.SimpleContentApps?color=0273B3)](https://www.nuget.org/packages/Umbraco.Community.SimpleContentApps)
[![GitHub license](https://img.shields.io/github/license/jcdcdev/Umbraco.Community.SimpleContentApps?color=8AB803)](https://github.com/jcdcdev/Umbraco.Community.SimpleContentApps/blob/main/LICENSE)
[![Downloads](https://img.shields.io/nuget/dt/Umbraco.Community.SimpleContentApps?color=cc9900)](https://www.nuget.org/packages/Umbraco.Community.SimpleContentApps/)

This packages aims to help developers quickly put together Umbraco ContentApps using C# only.

![Basic ContentApp in the Umbraco Office](https://raw.githubusercontent.com/jcdcdev/Umbraco.Community.SimpleContentApps/main/docs/screenshot.png)

## Features
- Simplifies C# based ContentApp creation
- Supports both Views & View Components
- No package.manifest or lang/lang.xml files required!
- Variant support (culture specific names)
- Easy to define Access Rules

## Quick Start

### Install Package
```csharp
dotnet add package Umbraco.Community.SimpleContentApps 
```

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