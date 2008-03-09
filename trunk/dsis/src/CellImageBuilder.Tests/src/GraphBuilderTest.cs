using System;
using DSIS.CellImageBuilder.AdaptiveMethod;
using DSIS.Core.System;
using DSIS.Function.Mock;
using DSIS.IntegerCoordinates.Tests;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.Tests
{
  [TestFixture]
  public class GraphBuilderTest : PointGraphBaseTest
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

    [Test]
    public void Test_05()
    {
      IGraphBuilder bld = myMock.TestCreateBuilder(1);
      Assert.AreEqual(1, bld.Dimension);

      IGraphBuilderProcessor ps = bld.Init(new MockIntegerCoordinateSystemInfo(1, 1));
      IFunction<double> function = new MockFunction<double>(1, delegate(double input) { return input; });
      PointGraph graph = new PointGraph(function, new double[]{0.1});

      ps.BuildGraph(graph, new double[]{0});

      AssertDumpWithCoordinates("build_05", graph.Nodes);
    }

    [Test]
    public void Test_06()
    {
      IGraphBuilder bld = myMock.TestCreateBuilder(2);
      Assert.AreEqual(2, bld.Dimension);

      IGraphBuilderProcessor ps = bld.Init(new MockIntegerCoordinateSystemInfo(2, 1));
      IFunction<double> function = new MockFunction<double>(2, delegate(double[] input, double[] output) { Array.Copy(input, output, 2); });
      PointGraph graph = new PointGraph(function, new double[]{0.1});

      ps.BuildGraph(graph, new double[]{0, 0});

      AssertDumpWithCoordinates("build_06", graph.Nodes);
    }

    [Test]
    public void Test_07()
    {
      IGraphBuilder bld = myMock.TestCreateBuilder(3);
      Assert.AreEqual(3, bld.Dimension);

      IGraphBuilderProcessor ps = bld.Init(new MockIntegerCoordinateSystemInfo(3, 1));
      IFunction<double> function = new MockFunction<double>(3, delegate(double[] input, double[] output) { Array.Copy(input, output, 2); });
      PointGraph graph = new PointGraph(function, new double[]{0.1});

      ps.BuildGraph(graph, new double[]{0, 0, 0});

      AssertDumpWithCoordinates("build_07", graph.Nodes);
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