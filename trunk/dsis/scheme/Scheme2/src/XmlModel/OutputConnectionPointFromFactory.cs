using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Scheme2.Impl.ConnectionPoints;
using DSIS.Scheme2.Impl.ObjectParsers;
using DSIS.Spring;

namespace DSIS.Scheme2.XmlModel
{
  [UsedBySpring]
  public class OutputConnectionPointFromFactory : Registrar<IOutputConnectionPointExtension, OutputConnectionPointFactory>, IOutputConnectionPointExtension
  {
    public OutputConnectionPointFromFactory(OutputConnectionPointFactory factory) : base(factory)
    {
    }

    public IOutputConnectionPoint Create(ISchemeGraphBuildContext ctx, XsdArc arc)
    {
      if (arc.Item is XsdEdgePoint)
      {
        XsdEdgePoint from = (XsdEdgePoint)arc.Item;

        return ctx.GetAction(from.Id).GetOutput(from.Point);
      }
      return null;
    }
  }
}