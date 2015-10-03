using System;
using DSIS.Core.Ioc;
using DSIS.Scheme2.Graph;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.ConnectionPoints.Xml.Output
{
  [UsedBySpring]
  public class OutputConnectionPointFactory :// AbstractRegistry<IOutputConnectionPointExtension>,
                                              IOutputConnectionPointExtension
  {
    public IOutputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcFrom arc)
    {
      throw new NotImplementedException();
//      return
//        ForEach<IOutputConnectionPoint>(
//          instance => instance.Create(ctx, arc));
    }
  }
}