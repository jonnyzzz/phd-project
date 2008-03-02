using DSIS.Scheme2.Graph;
using DSIS.Scheme2.XmlModel;
using DSIS.Spring;
using DSIS.Spring.Util;

namespace DSIS.Scheme2.ConnectionPoints.Xml.Input
{
  [UsedBySpring]
  public class InputConnectionPointExtension : Registrar<IInputConnectionPointExtension, InputConnectionPointFactory>,
                                               IInputConnectionPointExtension
  {
    public InputConnectionPointExtension(InputConnectionPointFactory factory) : base(factory)
    {
    }

    public IInputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcTO arc)
    {
      if (arc.Item is XsdEdgePoint)
      {
        XsdEdgePoint pt = (XsdEdgePoint) arc.Item;

        return ctx.GetAction(pt.Id).GetInput(pt.Point);
      }
      return null;
    }
  }
}