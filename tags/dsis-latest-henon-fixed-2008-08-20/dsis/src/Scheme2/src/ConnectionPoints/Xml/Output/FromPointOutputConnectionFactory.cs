using DSIS.Scheme2.Graph;
using DSIS.Scheme2.XmlModel;
using DSIS.Spring;
using DSIS.Spring.Util;

namespace DSIS.Scheme2.ConnectionPoints.Xml.Output
{
  [UsedBySpring]
  public class FromPointOutputConnectionFactory :
    Registrar<IOutputConnectionPointExtension, OutputConnectionPointFactory>, IOutputConnectionPointExtension
  {
    public FromPointOutputConnectionFactory(OutputConnectionPointFactory factory) : base(factory)
    {
    }

    public IOutputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcFrom arc)
    {
      if (arc.Item is XsdEdgePoint)
      {
        XsdEdgePoint from = (XsdEdgePoint) arc.Item;

        return ctx.GetAction(from.Id).GetOutput(from.Point);
      }
      return null;
    }
  }
}