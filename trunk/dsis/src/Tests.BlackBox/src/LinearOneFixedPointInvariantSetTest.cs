using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Linear;
using NUnit.Framework;

namespace DSIS.Tests.BlackBox
{
  [TestFixture]
  public class LinearOneFixedPointInvariantSetTest : InvariantSetTestBase
  {
    [SetUp]
    public override void SetUp()
    {
      base.SetUp();
      MethodSubdivision = new long[] { 5, 5 };
      mySystemSpace = new DefaultSystemSpace(2, new double[] { -2, -2 }, new double[] { 2, 2 }, new long[] { 3, 3 });
      mySystemInfo = new Linear2DSystemInfo(0.2, 0, 0, 0.2);    
    }


    [Test]
    public void Test_01()
    {
      DoTest(1, 1000, 2000, new double[]{2,2}, new double[][] {new double[] {0,0}, new double[] {1,1}});      
    }
  }
}