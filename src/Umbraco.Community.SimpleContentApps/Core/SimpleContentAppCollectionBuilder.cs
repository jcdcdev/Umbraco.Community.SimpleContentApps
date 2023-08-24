using Umbraco.Cms.Core.Composing;

namespace Umbraco.Community.SimpleContentApps.Core;

public class SimpleContentAppCollectionBuilder : OrderedCollectionBuilderBase<SimpleContentAppCollectionBuilder, SimpleContentAppCollection, ISimpleContentApp>
{
    protected override SimpleContentAppCollectionBuilder This { get; }
}
