using DSIS.CellImageBuilder.BoxAdaptiveMethod.Test;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.BexMethodTest
{
  [TestFixture]
  public class BoxMethodTest : MethodTestBase<BoxMethod, BoxMethodParameters>
  {
    [Test]
    public void Test_01()
    {
      DoTestOneDimensionAndAssert(0, 10, 10, 5, new BoxMethodParameters(0), delegate(double ins) { return ins; }, 5, 5);
    }
  }
}