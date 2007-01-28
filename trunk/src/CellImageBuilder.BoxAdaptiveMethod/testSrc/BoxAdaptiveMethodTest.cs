using NUnit.Framework;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod.Test
{
  [TestFixture]
  public class BoxAdaptiveMethodTest : MethodTestBase<BoxAdaptiveMethod, BoxAdaptiveMethodSettings>
  {
    [Test]
    public void Test_01()
    {
      BoxAdaptiveMethodSettings stategy = new BoxAdaptiveMethodSettings(
        100, BoxAdaptiveMethodStategy.Simple, 0.1);
      DoTestOneDimensionAndAssert(0, 10, 10,
                                  5, stategy,
                                  delegate(double ins) { return ins; }, 4, 6);
    }
  }
}
