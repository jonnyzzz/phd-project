using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph.Abstract;
using DSIS.Graph.Entropy.Impl.Loop;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph.Entropy
{
  [TestFixture]
  public class EntropyLoopIteratorCallbackTest : GraphBaseTest
  {
    [Test]
    public void Test_01()
    {
      double p = 0.25;
      DoTest2(l(l(1,2,3,4)), P(0, d(1,2,p), d(2,3,p), d(3,4,p), d(4,1,p)));
    }

    [Test]
    public void Test_02()
    {
      double p = 1.0/7.0;
      DoTest2(l(l(1,2,3,4,5,6,7)), P(0, d(1,2,p), d(2,3,p), d(3,4,p), d(4,5,p), d(5,6,p), d(6,7,p), d(7,1,p)));
    }

    [Test]
    public void Test_03()
    {
      double p = 1.0;
      DoTest2(l(l(1)), P(0, d(1,1,p)));
    }

    [Test]
    public void Test_04()
    {
      double p = 0.2;
      double q = 0.25;
      DoTest2(l(l(1,2,3,5), l(2,3,8,7,6)), P(0.22299, d(1,2,q), d(2,3, p+q), d(3,5,q), d(5,1,q), d(3,8,p), d(8,7,p), d(7,6,p), d(6,2,p)));
    }

    [Test]
    public void Test_05_one_node_loop()
    {
      DoTest2(l(l(1)), P(0, d(1, 1, 1)));
    }

    [Test]
    public void Test_06_two_node_loop()
    {
      DoTest2(l(l(1, 2)), P(0, d(1, 2, 0.5), d(2, 1, 0.5)));
    }

    [Test]
    public void Test_07_one_node_loop_proj()
    {
      DoTest2(l(l(1)), P(0, d(1, 1, 1)));
    }

    [Test]
    public void Test_08_two_node_loop()
    {
      DoTest2(l(l(1, 2)), P( 0, d(1, 2, 0.5), d(2, 1, 0.5)));
    }

    [Test][Ignore]
    public void  Test_09_project2()
    {
      //  1 -> 0
      //  2 -> 1
      //  3 -> 1
      //  4 -> 2  
      double q = 0.25;
      DoTest2(l(l(1,2,3,4)), 
        P(0, d(1,2,q), d(2,3,q), d(3,4,q), d(4,1,q)), 
          P(0.5, d(0,1,q), d(1,1,q), d(1,2,q),d(2,0,q)));
    }

    [Test]
    public void Test_10_project2()
    {
      double q = 0.25;
      double w = 0.5;

      DoTest2(l(l(0,2,4,6), l(1,3,5,7)), 
        P(0, d(0,2,q), d(1,3,q), d(2,4,q), d(3,5,q), d(4,6,q), d(5,7,q), d(6,0,q), d(7,1,q)),
        P(0, d(0,1,w), d(1,2,w), d(2,3,w), d(3, 0, w)));
    }

    [Test][Ignore]
    public void Test_11_project3()
    {
      double p = 0.2;
      double q = 0.25;
      DoTest2(l(l(1, 2, 3, 5), l(2, 3, 8, 7, 6)), 
        P(0.22299, d(1, 2, q), d(2, 3, p + q), d(3, 5, q), d(5, 1, q), d(3, 8, p), d(8, 7, p), d(7, 6, p), d(6, 2, p)),
        P(0.87299, d(0, 1, q), d(1, 1, p + q), d(1, 2, q), d(2, 0, q), d(1, 4, p), d(4, 3, p), d(3, 3, p), d(3, 1, p)),
        P(1.0676426732230349, d(0, 0, p + q + q), d(0, 1, q), d(1, 0, p + q), d(0, 2, p), d(2, 1, p), d(1, 1, p)),
        P(0.4529325012980811, d(0, 0, p + q + q + q + p + q + p), d(0, 1, p), d(1, 0, p)),
        P(0, d(0, 0, p + q + q + q + p + q + p + p + p)));
    }

    [Test]
    public void Test_12()
    {
      double p = 1.0/8.0;
      double q = 0.1;

      double v1 = 2*e(p) + e(2*(p + q)) + e(q) + e(q + q);
      double v2 = 3*e(p) + 4*e(q) + e(p + q);

      Console.Out.WriteLine("v1 = {0}", v1);
      Console.Out.WriteLine("v2 = {0}", v2);

      double v = v1 - v2;
      Console.Out.WriteLine("v = {0}", v);
//      Assert.AreEqual(v1, v2, 1e-5);
    }

    [Test]
    public void Test_foo()
    {
      double v1 = -1/6.0*Math.Log(2) - 1/4.0*Math.Log(3) + 5/12.0*Math.Log(5);
      double v2 = 2/5.0*Math.Log(2);

      Console.Out.WriteLine("v1 = {0}", v1);
      Console.Out.WriteLine("v2 = {0}", v2);

      Console.Out.WriteLine("v1-v2 = {0}", v1-v2);

    }
    private static double e(double e)
    {
      return e*Math.Log(e);
    }

    private static List<T> l<T>(params T[] ls)
    {
      return new List<T>(ls);
    }

    private static AssertData d(long i, long j, double d)
    {
      return new AssertData(i, j, d);
    }

    private static Pair<double, List<AssertData>> P(double e, params AssertData[] p)
    {
      return new Pair<double, List<AssertData>>(e, new List<AssertData>(p));
    }

    private class Listener : IEntropyListener<IntegerCoordinate>
    {
      public double Result;
      public IDictionary<IntegerCoordinate, double> Measure;

      public void OnResult(double result, IDictionary<IntegerCoordinate, double> measure)
      {
        Result = result;
        Measure = measure;
      }
    }

    private class Controller : Listener, IEntropyEvaluatorController<IntegerCoordinate>
    {
      private readonly IGraph<IntegerCoordinate> myGraph;
      private readonly IGraphStrongComponents<IntegerCoordinate> myComponents;

      public Controller(IGraph<IntegerCoordinate> graph, IGraphStrongComponents<IntegerCoordinate> components)
      {
        myGraph = graph;
        myComponents = components;
      }

      public IGraph<IntegerCoordinate> Graph
      {
        get { return myGraph; }
      }

      public IGraphStrongComponents<IntegerCoordinate> Components
      {
        get { return myComponents; }
      }

      public bool SubdivideNext(ICellCoordinateSystem<IntegerCoordinate> system)
      {
        return false;
      }

      public void SetCoordinateSystem(ICellCoordinateSystem<IntegerCoordinate> system)
      {
        
      }
    }
    
    protected static void DoTest2(List<List<int>> loops, params Pair<double, List<AssertData>>[] expected)
    {
      EntropyBackStepGraphWeightCallback<IntegerCoordinate> cb = DoTest(loops);
      double norm = -1;
      for (int i = 0; i < expected.Length; i++)
      {
        Pair<double, List<AssertData>> pair = expected[i];
        
        Listener listener = new Listener();

        cb.Entropy().ComputeEntropy(listener);
        double ent = listener.Result;

        if (i == 0)
          norm = cb.Norm;

        AssertNorm(cb, norm);
        try
        {
          Assert.AreEqual(ent, ComputeEntropy(pair.Second, cb.Norm), 1e-4, "Computed entropy differs");
          Assert.AreEqual(pair.First, ent, 1e-4);
          
          AssertResult(cb, pair.Second);
        }
        catch(Exception e)
        {
          Console.Error.WriteLine("step = {0}", i + 1);
          throw new Exception(e.Message, e);
        }

        if (i < expected.Length - 1)
          cb = cb.BackStep(new long[] {2});
      }
    }

    protected static EntropyBackStepGraphWeightCallback<IntegerCoordinate> DoTest(List<List<int>> loops)
    {
      TarjanGraph<IntegerCoordinate> graph = DoBuildGraph(delegate { });

      foreach (List<int> loop in loops)
      {
        foreach (int i in loop)
        {
          graph.AddNode(new IntegerCoordinate(i));
        }
      }

      EntropyBackStepGraphWeightCallback<IntegerCoordinate> cb =
        new EntropyBackStepGraphWeightCallback<IntegerCoordinate>(graph.CoordinateSystem, EntropyLoopConstantWeight.ONE);

      foreach (List<int> loop in loops)
      {
        List<INode<IntegerCoordinate>> nodes =
          loop.ConvertAll<INode<IntegerCoordinate>>(
            delegate(int input) { return graph.AddNode(new IntegerCoordinate(input)); });

        cb.OnLoopFound(nodes);
      }

      return cb;
    }

    private static void AssertNorm(EntropyGraphWeightCallback<IntegerCoordinate> cb, double expected)
    {
      Dictionary<IntegerCoordinate, double> myValuedIn = new Dictionary<IntegerCoordinate, double>(EqualityComparerFactory<IntegerCoordinate>.GetComparer());
      Dictionary<IntegerCoordinate, double> myValuedOut = new Dictionary<IntegerCoordinate, double>(EqualityComparerFactory<IntegerCoordinate>.GetComparer());

      double sum = 0;
      foreach (KeyValuePair<NodePair<IntegerCoordinate>, double> pair in cb.M)
      {
        double vIn;
        double vOut;
        myValuedIn.TryGetValue(pair.Key.To, out vIn);
        myValuedOut.TryGetValue(pair.Key.From, out vOut);

        myValuedIn[pair.Key.To] = vIn + pair.Value;
        myValuedOut[pair.Key.From] = vOut + pair.Value;

        sum += pair.Value;
      }

      Assert.AreEqual(myValuedIn.Count, myValuedOut.Count);

      foreach (IntegerCoordinate c in myValuedIn.Keys)
      {
        Assert.AreEqual(myValuedIn[c], myValuedOut[c], 1e-4);
      }

      Assert.AreEqual(expected, sum, 1e-4);
    }

    protected static void AssertResult(EntropyGraphWeightCallback<IntegerCoordinate> cb, List<AssertData> expected)
    {
      List<AssertData> weights = new List<AssertData>();
      foreach (KeyValuePair<NodePair<IntegerCoordinate>, double> pair in cb.M)
      {
        weights.Add(d(pair.Key.From.GetCoordinate(0), pair.Key.To.GetCoordinate(0), pair.Value));
      }

      weights.Sort();
      expected.Sort();

      try
      {
        Assert.AreEqual(expected.Count, weights.Count);

        for(int i=0; i<expected.Count; i++)
        {
          Assert.AreEqual(expected[i], weights[i]);
        }
      } catch(Exception e)
      {
        foreach (AssertData pair in weights)
        {
          Console.Out.WriteLine("pair = {0}", pair);
        }

        throw new Exception(e.Message, e);
      }
    }

    protected static double ComputeEntropy(IEnumerable<AssertData> data, double div)
    {
      Dictionary<long, double> nodeW = new Dictionary<long, double>();

      double e1 = 0;
      foreach (AssertData assertData in data)
      {
        double v;
        nodeW.TryGetValue(assertData.To, out v);
        double val = assertData.D/div;
        nodeW[assertData.To] = v + val;

        e1 += e(val);
      }

      double e2 = 0;
      foreach (KeyValuePair<long, double> pair in nodeW)
      {
        e2 += e(pair.Value);
      }

      return (e2 - e1) / Math.Log(2);
    }

    protected class AssertData : IEquatable<AssertData>, IComparable<AssertData>
    {
      public readonly long From;
      public readonly long To;
      public readonly double D;

      public AssertData(long from, long to, double d)
      {
        From = from;
        To = to;
        D = d;
      }

      public bool Equals(AssertData assertData)
      {
        if (assertData == null) return false;
        if (From != assertData.From) return false;
        if (To != assertData.To) return false;
        if (D != assertData.D) return false;
        return true;
      }

      public override bool Equals(object obj)
      {
        if (ReferenceEquals(this, obj)) return true;
        return Equals(obj as AssertData);
      }

      public override int GetHashCode()
      {
        int result = (int) From;
        result = 29*result + (int) To;
        result = 29*result + D.GetHashCode();
        return result;
      }

      public int CompareTo(AssertData other)
      {
        int v = From.CompareTo(other.From);
        if (v != 0)
          return v;

        v = To.CompareTo(other.To);
        if (v != 0)
          return v;

        return D.CompareTo(other.D);
      }

      public override string ToString()
      {
        return string.Format("{0}->{1}:{2}", From, To, D);
      }
    }
  }
}