using DSIS.CellImageBuilders.PointMethod;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Linear;
using NUnit.Framework;

namespace DSIS.Tests.BlackBox
{
  [TestFixture]
  public class ProjectorLinearSystemBoxMethodTest : ProjectorTestBase
  {    
    [SetUp]
    public override void SetUp()
    {
      base.SetUp();

      mySystemSpace = new DefaultSystemSpace(2, new double[] { -10, -10 }, new double[] { 10, 10 }, new long[] { 3, 3 });
      mySystemInfo = new Linear2DSystemInfo(mySystemSpace, 2,0,0,0.5);
    }
  }
  
  [TestFixture]
  public class ProjectorLinearSystemPointMethodTest : ProjectorLinearSystemBoxMethodTest
  {    
    [SetUp]
    public override void SetUp()
    {
      base.SetUp();
      Method = new PointMethodSettings(new int[] {2, 2});
    }
  }
}