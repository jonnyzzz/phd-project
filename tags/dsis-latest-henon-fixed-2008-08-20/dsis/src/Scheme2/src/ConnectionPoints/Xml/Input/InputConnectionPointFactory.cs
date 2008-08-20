using DSIS.Scheme2.Graph;
using DSIS.Scheme2.XmlModel;
using DSIS.Spring;
using DSIS.Spring.Util;

namespace DSIS.Scheme2.ConnectionPoints.Xml.Input
{
  [UsedBySpring]
  public class InputConnectionPointFactory : AbstractRegistry<IInputConnectionPointExtension>,
                                             IInputConnectionPointExtension
  {
    public IInputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcTO arc)
    {
      return
        ForEach<IInputConnectionPoint>(
          delegate(IInputConnectionPointExtension instance) { return instance.Create(ctx, arc); });
    }
  }
}