using DSIS.Core.Ioc;
using DSIS.Scheme2.Graph;
using DSIS.Scheme2.Nodes;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.ConnectionPoints.Xml.Output
{
  [UsedBySpring]
  public class ActionInstanceOutputConnectionPointFactory
    //Registrar<IOutputConnectionPointExtension, OutputConnectionPointFactory>, IOutputConnectionPointExtension
  {
    public ActionInstanceOutputConnectionPointFactory(OutputConnectionPointFactory factory)
      //: base(factory)
    {
    }

    public IOutputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcFrom arc)
    {
      if (arc.Item is XsdFromActionInstance)
      {
        var from = (XsdFromActionInstance) arc.Item;
        INode node = ctx.GetAction(from.Id);

        var action = (INodeAsOutputAction) node;
        return action.AsOutputConnectionPoint();
      }
      return null;
    }
  }
}