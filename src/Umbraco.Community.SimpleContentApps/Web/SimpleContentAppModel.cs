using Umbraco.Community.SimpleContentApps.Core;

namespace Umbraco.Community.SimpleContentApps.Web;

public class SimpleContentAppModel
{
    public ISimpleContentApp ContentApp { get; }
    public int NodeId { get; }

    public SimpleContentAppModel(ISimpleContentApp contentApp, int nodeId)
    {
        ContentApp = contentApp;
        NodeId = nodeId;
    }
}
