using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core.Configuration.Models;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Hosting;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Community.SimpleContentApps.Web;

namespace Umbraco.Community.SimpleContentApps.Core.Extensions;

public static class UmbracoBuilderExtensions
{
    public static SimpleContentAppCollectionBuilder Simple(this IUmbracoBuilder builder)
        => builder.WithCollectionBuilder<SimpleContentAppCollectionBuilder>();

    public static void AddSimpleContentApps(this IUmbracoBuilder builder)
    {
        var types = builder.TypeLoader.GetTypes<ISimpleContentApp>();
        foreach (var type in types)
        {
            builder.Simple().Append(type);
            var generic = typeof(SimpleContentAppFactory<>).MakeGenericType(type);
            builder.ContentApps().Append(generic);
        }

        builder.Services.Configure<UmbracoPipelineOptions>(options =>
        {
            options.AddFilter(new UmbracoPipelineFilter(nameof(RenderController))
            {
                Endpoints = app => app.UseEndpoints(endpoints =>
                {
                    var globalSettings = app.ApplicationServices
                        .GetRequiredService<IOptions<GlobalSettings>>().Value;
                    var hostingEnvironment = app.ApplicationServices
                        .GetRequiredService<IHostingEnvironment>();

                    endpoints.MapAreaControllerRoute(
                        $"umbraco-{nameof(SimpleContentAppController)}".ToLowerInvariant(),
                        // ReSharper disable once Mvc.AreaNotResolved
                        "SimpleContentApps",
                        $"{globalSettings.GetSimpleContentRenderUrl(hostingEnvironment)}/{{ContentApp}}/{{id}}",
                        new { controller = "SimpleContentApp", action = "Render" });
                })
            });
        });
    }
}
