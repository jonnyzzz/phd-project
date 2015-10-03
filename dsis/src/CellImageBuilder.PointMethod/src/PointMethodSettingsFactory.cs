using System;
using DSIS.CellImageBuilders.PointMethod;
using DSIS.Core.Ioc;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Scheme2.ObjectParsers;

namespace DSIS.CellImageBuilder.PointMethod
{
  [UsedBySpring]
  public class PointMethodSettingsFactory : SchemaBasedParser<XsdPointMethodSettings, PointMethodSettings>
  {
    public PointMethodSettingsFactory(ObjectParserFactory factory)
      : base(factory, typeof(PointMethodSettingsFactory), "resources.PointMethodSettings.xsd")
    {
    }

    protected override PointMethodSettings Parse(XsdPointMethodSettings obj)
    {
      throw new NotImplementedException();
/*
      if (obj.Overlaped)
      {
        return new PointMethodSettings(obj.Points);
      } else
      {
        return new PointMethodSettings(obj.Points, obj.Overlap);
      }
*/
    }
  }
}