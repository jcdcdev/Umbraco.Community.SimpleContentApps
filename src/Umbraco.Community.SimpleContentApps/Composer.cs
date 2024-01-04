using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Community.SimpleContentApps.Core.Extensions;

namespace Umbraco.Community.SimpleContentApps
{
    internal class Composer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.ManifestFilters().Append<ManifestFilter>();
            builder.AddSimpleContentApps();
        }
    }
}
