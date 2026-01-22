# Umbraco.Community.SimpleContentApps

[![Umbraco Marketplace](https://img.shields.io/badge/Umbraco Marketplace-%23f5c1bc?logo=umbraco&logoColor=162335)](https://marketplace.umbraco.com/package/Umbraco.Community.SimpleContentApps)
[![GitHub](https://img.shields.io/badge/GitHub-1?logo=github&color=232925)](https://github.com/jcdcdev/Umbraco.Community.SimpleContentApps)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Umbraco.Community.SimpleContentApps?labelColor=4536d3&color=4536d3&label=NuGet&logo=nuget)](https://www.nuget.org/packages/Umbraco.Community.SimpleContentApps)
[![Project Website](https://img.shields.io/badge/Project Website-jcdcdev?color=3c4834&logo=data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSIxNiIgaGVpZ2h0PSIxNiIgZmlsbD0id2hpdGUiIGNsYXNzPSJiaSBiaS1wYy1kaXNwbGF5IiB2aWV3Qm94PSIwIDAgMTYgMTYiPgogIDxwYXRoIGQ9Ik04IDFhMSAxIDAgMCAxIDEtMWg2YTEgMSAwIDAgMSAxIDF2MTRhMSAxIDAgMCAxLTEgMUg5YTEgMSAwIDAgMS0xLTF6bTEgMTMuNWEuNS41IDAgMSAwIDEgMCAuNS41IDAgMCAwLTEgMG0yIDBhLjUuNSAwIDEgMCAxIDAgLjUuNSAwIDAgMC0xIDBNOS41IDFhLjUuNSAwIDAgMCAwIDFoNWEuNS41IDAgMCAwIDAtMXpNOSAzLjVhLjUuNSAwIDAgMCAuNS41aDVhLjUuNSAwIDAgMCAwLTFoLTVhLjUuNSAwIDAgMC0uNS41TTEuNSAyQTEuNSAxLjUgMCAwIDAgMCAzLjV2N0ExLjUgMS41IDAgMCAwIDEuNSAxMkg2djJoLS41YS41LjUgMCAwIDAgMCAxSDd2LTRIMS41YS41LjUgMCAwIDEtLjUtLjV2LTdhLjUuNSAwIDAgMSAuNS0uNUg3VjJ6Ii8+Cjwvc3ZnPg==)](https://jcdc.dev/umbraco-packages/simple-content-apps)


This packages aims to help developers quickly put together Umbraco ContentApps using C#.

- Simplifies C# based ContentApp creation
- Supports both Views & View Components
- No package.manifest or lang/lang.xml files required!
- Variant support (culture specific names)
- Easy to define Access Rules

Looking for Umbraco Workspace Views? Check out [Umbraco.Community.SimpleWorkspaceViews](https://github.com/jcdcdev/Umbraco.Community.SimpleWorkspaceViews)


> [!IMPORTANT]
> Version 13 will only receive security updates and no new features.

> Please review the [security policy](https://github.com/jcdcdev/Umbraco.Community.SimpleContentApps?tab=security-ov-file#supported-versions) for more information.

## Installation

### Install Package
```powershell
dotnet add package Umbraco.Community.SimpleContentApps 
```

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

## Extending

[docs/examples.md](https://github.com/jcdcdev/Umbraco.Community.SimpleContentApps/blob/v13/docs/examples.md)


## Contributing

Contributions to this package are most welcome! Please visit the [Contributing](https://github.com/jcdcdev/Umbraco.Community.SimpleContentApps/contribute) page.

## Acknowledgements (Thanks)

- LottePitcher - [opinionated-package-starter](https://github.com/LottePitcher/opinionated-package-starter)
- jcdcdev - [jcdcdev.Umbraco.PackageTemplate](https://github.com/jcdcdev/jcdcdev.Umbraco.PackageTemplate)



