using System;
using DSIS.Core.Ioc;
using DSIS.Scheme2.Graph;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.ConnectionPoints.Xml.Input
{
  [UsedBySpring]
  public class InputConnectionPointFactory : //AbstractRegistry<IInputConnectionPointExtension>,
                                             IInputConnectionPointExtension
  {
    public IInputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdConnectionsArcTO arc)
    {
      throw new NotImplementedException();
//      return
//        ForEach<IInputConnectionPoint>(
//          delegate(IInputConnectionPointExtension instance) { return instance.Create(ctx, arc); });
    }
  }
}