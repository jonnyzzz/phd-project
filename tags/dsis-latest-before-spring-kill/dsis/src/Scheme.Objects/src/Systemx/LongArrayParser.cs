using DSIS.Scheme2.ObjectParsers;
using DSIS.Spring;

namespace DSIS.Scheme.Objects.Systemx
{
  [UsedBySpring]
  public class LongArrayParser : SchemaBasedParser<XsdLongArray, long[]>
  {
    public LongArrayParser(ObjectParserFactory factory)
      : base(factory, "resources.IntArray.xsd")
    {
    }

    protected override long[] Parse(XsdLongArray obj)
    {
      return obj.Value;
    }
  }
}