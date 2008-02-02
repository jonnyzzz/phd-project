using System;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Linear;
using DSIS.IntegerCoordinates.Tests;
using DSIS.TrajectoryBuilder;
using NUnit.Framework;

namespace DSIS.Trajectory.Tests
{
  [TestFixture]
  public class SimpleTrajectoryBuilderTest
  {    
    [Test]
    public void Test_01()
    {
      //x -> 0.5x
      MockSystemSpace space = new MockSystemSpace(1,0,1,1000);
      Linear1DSystemInfo linear = new Linear1DSystemInfo(space, 0.5, 0);
   
      SimpleTrajectoryBuilder bld = new SimpleTrajectoryBuilder(space, linear, 10000);

      double v = 1;
      bld.Point = new double[] {v};

      for(int i=0; i<1000; i++)
      {
        Assert.AreEqual(v, bld.Point[0]);
        bld.Next();
        v /= 2;
      }      
    }

    [Test]
    public void TestConverge()
    {
      ISystemSpace mySystemSpace = new DefaultSystemSpace(2, new double[] { -2, -2 }, new double[] { 2, 2 }, new long[] { 3, 3 });
      ISystemInfo mySystemInfo = new Linear2DSystemInfo(mySystemSpace, 0.2, 0, 0, 0.2);

      for (double dx = -2; dx < 2; dx += 0.01)
      {
        for (double dy = -2; dy < 2; dy += 0.01)
        {
          SimpleTrajectoryBuilder bld = new SimpleTrajectoryBuilder(mySystemSpace, mySystemInfo, 1 << 40);

          bld.Point = new double[] { dx, dy };

          bool success = false;
          for (int i = 0; i < 1000; i++)
          {
            bld.Next();
            if (Math.Abs(bld.Point[0]) < 1e-5 && Math.Abs(bld.Point[1]) < 1e-5)
            {
              success = true;
              break;
            }
          }

          Assert.IsTrue(success, "Does not converge");
        }
      }
    }
  }
}