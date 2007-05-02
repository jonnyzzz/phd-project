using DSIS.Core.System;
using DSIS.Function.Mock;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  [TestFixture]
  public class GraphBuilderTest
  {
    private Mock myMock;

    [SetUp]
    public void SetUp()
    {
      myMock = new Mock();      
    }

    [Test]
    public void Test_01_CanCompile()
    {
      myMock.TestCreateBuilder(1);
    }

    [Test]
    public void Test_02_CanCompile()
    {
      myMock.TestCreateBuilder(2);
    }

    [Test]
    public void Test_03_CanCompile()
    {
      myMock.TestCreateBuilder(3);
    }

    [Test]
    public void Test_04_CanCompile()
    {
      myMock.TestCreateBuilder(4);
    }

    public void Test_05()
    {
      IGraphBuilder bld = myMock.TestCreateBuilder(1);
      Assert.AreEqual(1, bld.Dimension);

      IGraphBuilderProcessor ps = bld.Init(new MockIntegerCoordinateSystemInfo(1, 1));
      IFunction<double> function = new MockFunction<double>(1, delegate(double input) { return input; });
      PointGraph graph = new PointGraph(function, new double[]{0.3});

    }

    private class Mock : PointGraphInitialBuilder
    {
      public IGraphBuilder TestCreateBuilder(int dim)
      {
        return GenerateCode(dim);
      }
    }
    
  }
}