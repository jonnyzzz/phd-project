using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Function.Predefined.Henon;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace DSIS.Scheme.Impl.Tests
{
  [TestFixture]
  public class SimbolicImageBuildTest : SimbolicImageBuildTestBase
  {
    private readonly ISystemSpace mySystemSpace;
    private readonly ISystemInfo mySystemInfo;

    public SimbolicImageBuildTest()
    {
      mySystemSpace = new DefaultSystemSpace(2, new double[] { -10, -10 }, new double[] { 10, 10 }, new long[] { 3, 3 });
      mySystemInfo = new HenonFunctionSystemInfoDecorator(1.4);
    }

    protected override ISystemInfo SystemInfo
    {
      get { return mySystemInfo; }
    }

    protected override ISystemSpace SystemSpace
    {
      get { return mySystemSpace; }
    }

    [Test]
    public void Test_CellsInctement()
    {
      var b = new AssertGraphAction
                {
                  CompontentsCountConstraint = new GreaterThanOrEqualConstraint(1),
                  CompontentsNodesCountConstraint = new GreaterThanOrEqualConstraint(10),
                  GraphNodesConstraint = new GreaterThanOrEqualConstraint(56),
                  GraphEdgesConstraint = new GreaterThanOrEqualConstraint(100)
                };

      DoTest(3, (ad, leaf) => ad.AddEdge(leaf, b));
    }     
  }
}