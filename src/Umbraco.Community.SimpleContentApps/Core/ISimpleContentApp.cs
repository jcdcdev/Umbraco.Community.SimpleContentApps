﻿using Umbraco.Cms.Core.Dashboards;
using Umbraco.Cms.Core.Models.ContentEditing;
using Umbraco.Cms.Core.Models.Entities;

namespace Umbraco.Community.SimpleContentApps.Core;

public interface ISimpleContentApp
{
    bool ShowInContent { get; }
    bool ShowInContentType { get; }
    bool ShowInMedia { get; }
    bool ShowInMembers { get; }
    IAccessRule[] Rules { get; }
    int Weight { get; }
    string Icon { get; }
    string? CultureName(string? currentUiCulture);
    string Name { get; }
    ContentAppBadge? Badge { get; }
    bool ShouldShow(IUmbracoEntity source) => true;
}
