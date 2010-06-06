using System;
using System.Collections.Generic;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Tests;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph.Entropy.Tests
{
  [TestFixture]
  public class GraphMeasureTest
  {

    [Test]
    public void Test_01()
    {
      DoProjectTest(ll(a(1,1,1)), 1, 2, ll(a(0,0,1)));      
    }

    [Test]
    public void Test_02()
    {
      DoProjectTest(ll(a(2,1,1), a(2,2,1)), 2, 2, ll(a(1,0,1), a(1,1,1)));      
    }

    [Test]
    public void Test_03_sum()
    {
      DoProjectTest(ll(a(2,2,1), a(2,3,1)), 2, 2, ll(a(1,1,2)));      
    }
   

    private static void DoProjectTest(IEnumerable<Arc> arcs, double norm, long project, IEnumerable<Arc> projected)
    {
      var M = new Dictionary<PairBase<IntegerCoordinate>, double>();
      foreach (Arc arc in arcs)
      {
        M.Add(arc.Ar, arc.value);
      }

      IGraphMeasure<IntegerCoordinate> meas = new GraphMeasure<IntegerCoordinate, PairBase<IntegerCoordinate>>("ZZz", M,
                                                                       IntegerCoordinateEqualityComparer.INSTANCE, norm,
                                                                       new IntegerCoordinateSystem(
                                                                         new MockSystemSpace(1, 0, 1000, 1000)));

      IGraphMeasure<IntegerCoordinate> prj = meas.Project(meas.CoordinateSystem.Project(new[]{project}));

      var list = new List<Pair<PairBase<IntegerCoordinate>, double>>(prj.Measure);
      var gold = new List<Arc>(projected);

      var hash = new Dictionary<NodePair<IntegerCoordinate>, double>(new NodePairEqualityComparer<IntegerCoordinate>());
      var w = gold.FoldLeft(0.0, (x,v)=>x.value+v);      
      foreach (Arc arc in gold)
      {
        hash.Add(arc.Ar, arc.value/w);
      }

      try
      {
        Assert.AreEqual(gold.Count, list.Count);

        foreach (Pair<PairBase<IntegerCoordinate>, double> pair in list)
        {         
          var np = (NodePair<IntegerCoordinate>)pair.First;
          Assert.That(hash.ContainsKey(np), Is.True);
          Assert.That(hash[np], Is.EqualTo(pair.Second));
        }
      } catch(Exception e)
      {
        Console.Out.WriteLine("Result:");
        foreach (Pair<PairBase<IntegerCoordinate>, double> pair in list)
        {
          Console.Out.WriteLine("pair = {0}, {1}", pair.First, pair.Second);
        }
        throw new Exception(e.Message, e);
      }
    }

    private static T[] ll<T>(params T[] t)
    {
      return t;
    }

    private static Arc a(int from, int to, double value)
    {
      return new Arc(new NodePair<IntegerCoordinate>(new IntegerCoordinate(from), new IntegerCoordinate(to)),  value);
    }

    private struct Arc
    {
      public readonly NodePair<IntegerCoordinate> Ar;
      public readonly double value;

      public Arc(NodePair<IntegerCoordinate> ar, double value)
      {
        Ar = ar;
        this.value = value;
      }
    }
  }
}