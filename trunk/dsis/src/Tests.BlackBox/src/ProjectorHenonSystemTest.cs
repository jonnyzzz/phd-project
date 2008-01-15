using DSIS.CellImageBuilders.PointMethod;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Henon;
using NUnit.Framework;

namespace DSIS.Tests.BlackBox
{
  [TestFixture]
  public class ProjectorHenonSystemBoxMethodTest : ProjectorTestBase
  {
    [SetUp]
    public override void SetUp()
    {
      base.SetUp();

      mySystemSpace = new DefaultSystemSpace(2, new double[] {-10, -10}, new double[] {10, 10}, new long[] {3, 3});
      mySystemInfo = new HenonFunctionSystemInfoDecorator(mySystemSpace, 1.4);
    }
  }

  [TestFixture]
  public class ProjectorHenonSystemPointMethodTest : ProjectorHenonSystemBoxMethodTest
  {
    [SetUp]
    public override void SetUp()
    {
      base.SetUp();
      Method = new PointMethodSettings(new int[] {3, 3});
    }
  }
}