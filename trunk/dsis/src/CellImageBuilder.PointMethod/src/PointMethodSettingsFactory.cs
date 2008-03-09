using DSIS.CellImageBuilders.PointMethod;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Scheme2.ObjectParsers;
using DSIS.Spring;

[assembly: SpringConfigXml("resources.spring.xml", Type=typeof(PointMethodSettingsFactory))]

namespace DSIS.CellImageBuilders.PointMethod
{
  [UsedBySpring]
  public class PointMethodSettingsFactory : SchemaBasedParser<XsdPointMethodSettings, PointMethodSettings>
  {
    public PointMethodSettingsFactory(ObjectParserFactory factory, string schema) : base(factory, schema)
    {
    }

    protected override PointMethodSettings Parse(XsdPointMethodSettings obj)
    {
      if (obj.Overlaped)
      {
        return new PointMethodSettings(obj.Points);
      } else
      {
        return new PointMethodSettings(obj.Points, obj.Overlap);
      }
    }
  }
}