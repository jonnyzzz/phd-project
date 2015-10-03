using DSIS.CellImageBuilder.BoxMethod;
using DSIS.Scheme.Objects.Systemx;
using DSIS.Scheme2.ObjectParsers;
using DSIS.Spring;

[assembly: SpringConfigXml("resources.spring.xml", Type = typeof(BoxMethodSettingsFactory))]

namespace DSIS.CellImageBuilder.BoxMethod
{
  [UsedBySpring]
  public class BoxMethodSettingsFactory : SchemaBasedParser<XsdBoxMethodSettings, BoxMethodSettings>
  { 
    public BoxMethodSettingsFactory(ObjectParserFactory factory) : base(factory, typeof(BoxMethodSettingsFactory), "resources.BoxMethodSettings.xsd")
    {
    }

    protected override BoxMethodSettings Parse(XsdBoxMethodSettings obj)
    {
      return new BoxMethodSettings(obj.Eps);
    }
  }
}