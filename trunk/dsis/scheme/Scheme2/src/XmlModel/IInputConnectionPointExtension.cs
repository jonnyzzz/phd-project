using DSIS.Spring;

namespace DSIS.Scheme2.XmlModel
{
  public interface IInputConnectionPointExtension
  {
    IInputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcTO arc);
  }

  [UsedBySpring]
  public class InputConnectionPointExtension : Registrar<IInputConnectionPointExtension, InputConnectionPointFactory>, IInputConnectionPointExtension
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