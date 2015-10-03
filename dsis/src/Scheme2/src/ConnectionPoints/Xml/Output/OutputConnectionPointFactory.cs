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
          delegate(IOutputConnectionPointExtension instance) { return instance.Create(ctx, arc); });
    }
  }
}