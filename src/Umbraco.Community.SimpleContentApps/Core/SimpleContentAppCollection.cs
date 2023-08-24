using Umbraco.Cms.Core.Composing;

namespace Umbraco.Community.SimpleContentApps.Core;

public class SimpleContentAppCollection : BuilderCollectionBase<ISimpleContentApp>
{
    public SimpleContentAppCollection(Func<IEnumerable<ISimpleContentApp>> items) : base(items)
    {
    }
}