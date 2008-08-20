using System;
using System.Collections.Generic;
using System.Text;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.Core.System.Impl;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Persistance.Tests
{
  [TestFixture]
  public class GraphMeasurePersistanceTest : PersistanceTestBase
  {
    private IPersistance<IGraphMeasure> myPersistance;

    [SetUp]
    public void SetUp()
    {
      
      var ps = 
        new IntegerCoordinatePersistanceProxy(
          new IntegerCoordinatePersistance(
            new DefaultSystemSpacePersistance(),
            new GeneratedIntegerCoordinateSystemManager(
              CodeCompiler.CodeCompiler.CreateCompiler())
            ));

      myPersistance = new GraphMeasurePersistance(ps);

    }

    [Test]
    public void Test_01()
    {
      DoTest(1);
    }

    [Test]
    public void Test_02()
    {
      DoTest(2);
    }

    [Test]
    public void Test_03()
    {
      DoTest(3);
    }

    private void DoTest(int dim)
    {
      GraphMeasure<IntegerCoordinate, NodePair<IntegerCoordinate>> m = CreateGraphMeasure(dim);

      DoTest2(m, (w,x)=>myPersistance.Save(x,w), r => myPersistance.Load(r), AssertM);
    }

    public static GraphMeasure<IntegerCoordinate, NodePair<IntegerCoordinate>> CreateGraphMeasure(int dim)
    {
      var ics = new Dictionary<NodePair<IntegerCoordinate>,double>();
      for(long i=0; i<100; i++)
      {
        ics.Add(
          new NodePair<IntegerCoordinate>(
            new IntegerCoordinate(i.Fill(dim)),
            new IntegerCoordinate(i.Fill(dim))), i
          );
      }


      return new GraphMeasure<IntegerCoordinate, NodePair<IntegerCoordinate>>(
        "aaa", ics, EqualityComparerFactory<IntegerCoordinate>.GetComparer(), 4, 
        new IntegerCoordinateSystem(
          new DefaultSystemSpace(dim, 1.0.Fill(dim), 2.0.Fill(dim), 55555L.Fill(dim)))
        );
    }

    public static void AssertM(IGraphMeasure a, IGraphMeasure b)
    {
      var qA = new WithQ();
      var qB = new WithQ();

      a.DoCallback(qA);
      b.DoCallback(qB);

      Assert.AreEqual(qA, qB);
    }
  
    private class WithQ : IGraphMeasureWith, IEquatable<WithQ>
    {
      private string myCode;
      private ISystemSpace mySpace;

      public void WithGraphMeasure<Q>(IGraphMeasure<Q> measure) where Q : ICellCoordinate
      {
        mySpace = measure.CoordinateSystem.SystemSpace;
        myCode = measure.Method  + "|" + SaveMeasureEdges(measure);
      }

      public bool Equals(WithQ obj)
      {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return Equals(obj.myCode, myCode) && Equals(obj.mySpace, mySpace);
      }

      public override bool Equals(object obj)
      {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != typeof (WithQ)) return false;
        return Equals((WithQ) obj);
      }

      public override int GetHashCode()
      {
        return 0;
      }

      public override string ToString()
      {
        return mySpace.ToString() + "\r\n" + myCode;
      }
    }
    private static string SaveMeasureEdges<Q>(IGraphMeasure<Q> measure) where Q : ICellCoordinate
    {
      var dim = measure.CoordinateSystem.Dimension;
      var list = new List<string>();

      foreach (Pair<PairBase<Q>, double> pair in measure.Measure)
      {
       var sb = new StringBuilder();
        foreach (Q q in new[]{pair.First.From, pair.First.To})
        {
          ToString(dim, sb, q);
        }
        sb.Append(pair.Second);
        list.Add(sb.ToString());
      }
      list.Sort();
      return list.FoldLeft(new StringBuilder(), (x, r) =>
                                                  {
                                                    r.AppendLine(x);
                                                    return r;
                                                  }).ToString();
    }

    private static void ToString<Q>(int dim, StringBuilder sb, Q q) where Q: ICellCoordinate
    {
      foreach(int i in dim.Each())
      {
        sb.AppendFormat("{0} ", ((IIntegerCoordinate)(object) q).GetCoordinate(i));
      }
    }

    private static void AssertM(IGraphMeasure<IntegerCoordinate> a, IGraphMeasure<IntegerCoordinate> b)
    {
      Assert.AreEqual(a.Method, b.Method);
      Assert.AreEqual(a.CoordinateSystem, b.CoordinateSystem);

      var dA = Fill(a);
      var dB = Fill(b);

      Assert.AreEqual(dA.Count, dB.Count);

      foreach (var pair in dA)
      {
        Assert.IsTrue(dB.ContainsKey(pair.Key));
        Assert.AreEqual(dB[pair.Key], pair.Value);
      }
      
      Assert.AreEqual(b.GetEntropy(), a.GetEntropy());
    }

    private static Dictionary<NodePair<IntegerCoordinate>, double> Fill(IGraphMeasure<IntegerCoordinate> m)
    {
      var d = new Dictionary<NodePair<IntegerCoordinate>, double>(EqualityComparerFactory<NodePair<IntegerCoordinate>>.GetComparer());

      foreach (Pair<PairBase<IntegerCoordinate>, double> pair in m.Measure)
      {
        d.Add(new NodePair<IntegerCoordinate>(pair.First.From, pair.First.To), pair.Second);
      }
      return d;
    }

  }
}