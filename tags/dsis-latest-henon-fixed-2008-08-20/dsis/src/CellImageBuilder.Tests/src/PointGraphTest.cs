using DSIS.CellImageBuilder.AdaptiveMethod;
using DSIS.Core.System;
using DSIS.Function.Mock;
using NUnit.Framework;

namespace DSIS.CellImageBuilder.Tests
{
  [TestFixture]
  public class PointGraphTest : PointGraphBaseTest
  {
    private IFunction<double> myFunction;
    private double[] myEps;
    private PointGraph myGraph;

    [SetUp]
    public void SetUp()
    {
      myFunction = new MockFunction<double>(1, delegate(double ins) { return ins; });
      myEps = new double[] {1};
      myGraph = new PointGraph(myFunction, myEps);
    }


    [Test]
    public void Test_01()
    {
      PointGraphNode n1 = myGraph.CreateNodeCopy(1);
      PointGraphNode n2 = myGraph.CreateNodeCopy(2);

      double[] ds = new double[1];
      myGraph.ComputeDistance(n1, n2, ds);

      Assert.AreEqual(1, ds[0], 1e-8);
    }

    [Test]
    public void Test_02()
    {
      PointGraphNode n1 = myGraph.CreateNodeCopy(0);
      PointGraphNode n2 = myGraph.CreateNodeCopy(2);

      Assert.IsFalse(myGraph.CheckDistance(n1, n2));
    }

    [Test]
    public void Test_03()
    {
      PointGraphNode n1 = myGraph.CreateNodeCopy(0);
      PointGraphNode n2 = myGraph.CreateNodeCopy(2);
      myGraph.AddEdge(n1, n2);

      AssertDump("test_03", n1, n2);      
    }

    [Test]
    public void Test_04_split()
    {
      PointGraphNode n1 = myGraph.CreateNodeCopy(0);
      PointGraphNode n2 = myGraph.CreateNodeCopy(2);
      myGraph.AddEdge(n1, n2);

      PointGraphNode m = myGraph.Subdivide(n1, n2).First;

      Assert.AreEqual(1, m.PointX[0], 1e-8);
      Assert.AreEqual(0, n1.PointX[0], 1e-8);
      Assert.AreEqual(2, n2.PointX[0], 1e-8);

      AssertDump("test_04", n1, n2);      
    }

    [Test]
    public void Test_05()
    {
      PointGraphNode n1 = myGraph.CreateNodeCopy(0);
      PointGraphNode n2 = myGraph.CreateNodeCopy(2);
      PointGraphNode n3 = myGraph.CreateNodeCopy(5);
      myGraph.AddEdge(n1, n2);
      myGraph.AddEdge(n1, n3);
      myGraph.AddEdge(n2, n3);
 
      AssertDump("test_05", n1, n2, n3);      
    }

    [Test]
    public void Test_06_split()
    {
      PointGraphNode n1 = myGraph.CreateNodeCopy(0);
      PointGraphNode n2 = myGraph.CreateNodeCopy(2);
      PointGraphNode n3 = myGraph.CreateNodeCopy(5);
      myGraph.AddEdge(n1, n2);
      myGraph.AddEdge(n1, n3);
      myGraph.AddEdge(n2, n3);

      PointGraphNode m = myGraph.Subdivide(n1, n2).First;

      Assert.AreEqual(1, m.PointX[0], 1e-8);
      Assert.AreEqual(0, n1.PointX[0], 1e-8);
      Assert.AreEqual(2, n2.PointX[0], 1e-8);

 
      AssertDump("test_06", n1, n2, n3);      
    }
  }
}