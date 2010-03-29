using DSIS.Core.Ioc;
using DSIS.Scheme2.ObjectParsers;

namespace DSIS.Scheme.Objects.Systemx
{
  [ComponentImplementation]
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