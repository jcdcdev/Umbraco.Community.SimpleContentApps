using Umbraco.Extensions;

namespace Umbraco.Community.SimpleContentApps.Core.Extensions;

public static class SimpleContentAppExtensions
{
    public static string Alias(this ISimpleContentApp app)
    {
        return GetName(app).TrimEnd("ContentApp");
    }

    public static string ViewComponent(this ISimpleContentApp app)
    {
        return $"{GetName(app)}ViewComponent";
    }

    public static string GetName(this ISimpleContentApp app)
    {
        return app.GetType().Name;
    }
}
