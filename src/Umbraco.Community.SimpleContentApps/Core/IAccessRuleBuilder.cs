﻿using Umbraco.Cms.Core.Dashboards;

namespace Umbraco.Community.SimpleContentApps.Core;

public interface IAccessRuleUserGroupBuilder
{
    IAccessRule UserGroup(string userGroup);
}

public interface IAccessRuleSectionBuilder
{
    IAccessRule Section(string section);
}

public interface IAccessRuleBuilder : IAccessRuleUserGroupBuilder
{
}
