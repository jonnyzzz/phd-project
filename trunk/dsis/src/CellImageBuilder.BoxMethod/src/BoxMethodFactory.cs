using DSIS.Scheme.Objects.Systemx;
using DSIS.Scheme2.ObjectParsers;
using DSIS.Spring;

namespace DSIS.CellImageBuilder.BoxMethod
{
  [UsedBySpring]
  public class BoxMethodFactory : SchemaBasedParser<XsdBoxMethodSettings, BoxMethodSettings>
  {
    public BoxMethodFactory(ObjectParserFactory factory, string schema) : base(factory, schema)
    {
    }

    protected override BoxMethodSettings Parse(XsdBoxMethodSettings obj)
    {
      return new BoxMethodSettings(obj.Eps);
    }
  }
}