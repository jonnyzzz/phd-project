using DSIS.Scheme2.ObjectParsers;
using DSIS.Spring;

namespace DSIS.Scheme.Objects.Systemx
{
  [UsedBySpring]
  public class DoubleArrayParser : SchemaBasedParser<XsdDoubleArray, double[]>
  {
    public DoubleArrayParser(ObjectParserFactory factory)
      : base(factory, "resources.DoubleArray.xsd")
    {
    }

    protected override double[] Parse(XsdDoubleArray obj)
    {
      return obj.Value;
    }
  }
}