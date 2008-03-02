using DSIS.Spring;

namespace DSIS.Scheme2.XmlModel
{
  [UsedBySpring]
  public class OutputConnectionPointFromActionFactory : Registrar<IOutputConnectionPointExtension, OutputConnectionPointFactory>, IOutputConnectionPointExtension
  {
    public OutputConnectionPointFromActionFactory(OutputConnectionPointFactory factory)
      : base(factory)
    {
    }

    public IOutputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcFrom arc)
    {
      if (arc.Item is XsdFromActionInstance)
      {
        XsdFromActionInstance from = (XsdFromActionInstance)arc.Item;
        INode node = ctx.GetAction(from.Id);

        INodeAsOutputAction action = (INodeAsOutputAction)node;        
        return action.AsOutputConnectionPoint();        
      }
      return null;
    }
  }
}