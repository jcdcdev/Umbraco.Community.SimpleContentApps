using Umbraco.Extensions;

namespace Umbraco.Community.SimpleContentApps.Core.Extensions;

public static class SimpleContentAppExtensions
{
    public static string Alias(this ISimpleContentApp app)
    {
        return app.GetType().Name.TrimEnd("ContentApp");
    }

    public static string ViewComponent(this ISimpleContentApp app)
    {
        return app.GetType().Name + "ViewComponent";
    }
}
