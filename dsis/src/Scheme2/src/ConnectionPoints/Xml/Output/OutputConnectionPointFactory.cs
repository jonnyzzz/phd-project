using DSIS.Scheme2.Graph;
using DSIS.Scheme2.XmlModel;
using DSIS.Spring;
using DSIS.Spring.Util;

namespace DSIS.Scheme2.ConnectionPoints.Xml.Output
{
  [UsedBySpring]
  public class OutputConnectionPointFactory : AbstractRegistry<IOutputConnectionPointExtension>,
                                              IOutputConnectionPointExtension
  {
    public IOutputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcFrom arc)
    {
      return
        ForEach<IOutputConnectionPoint>(
          instance => instance.Create(ctx, arc));
    }
  }
}