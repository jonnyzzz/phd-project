using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Morse.JVR;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;
using NUnit.Framework;

namespace DSIS.Graph.Morse.Tests
{
  public class MorsePureTestBase
  {
    protected class CostContext : IMorseEvaluatorGraph<INode<IntegerCoordinate>>, IMorseEvaluatorCost<INode<IntegerCoordinate>>
    {
      private readonly Dictionary<int, INode<IntegerCoordinate>> myCache = new Dictionary<int, INode<IntegerCoordinate>>();
      private readonly List<INode<IntegerCoordinate>> myCoordinates = new List<INode<IntegerCoordinate>>();
      private readonly Dictionary<IntegerCoordinate, double> myWeights = new Dictionary<IntegerCoordinate, double>(EqualityComparerFactory<IntegerCoordinate>.GetComparer());
      private readonly Dictionary<INode<IntegerCoordinate>, List<INode<IntegerCoordinate>>> myEdges = new Dictionary<INode<IntegerCoordinate>, List<INode<IntegerCoordinate>>>(EqualityComparerFactory<INode<IntegerCoordinate>>.GetComparer());

      public void AddCost(int id, double v)
      {
        var c = new IntegerCoordinate(id);
        var n = new FakeINode(c);
        myCoordinates.Add(n);
        myEdges[n] = new List<INode<IntegerCoordinate>>();
        myWeights[c] = v;
        myCache.Add(id, n);
      }

      public void AddCost(int id, double v, string base64)
      {
        AddCost(id, v);
      }

      public void AddEdge(int fromId, int toId)
      {
        myEdges[myCache[fromId]].Add(myCache[toId]);
      }

      public IEnumerable<INode<IntegerCoordinate>> GetNodes(INode<IntegerCoordinate> node)
      {
        return myEdges[node];
      }

      public IEnumerable<INode<IntegerCoordinate>> GetNodes()
      {
        return myCoordinates;
      }

      public IEqualityComparer<INode<IntegerCoordinate>> Comparer
      {
        get { return new ReferenceEqualityComparer<INode<IntegerCoordinate>>(); }
      }

      public double Cost(INode<IntegerCoordinate> node)
      {
        return myWeights[node.Coordinate];
      }

      private class FakeINode : INode<IntegerCoordinate>
      {
        private readonly IntegerCoordinate myValue;

        public FakeINode(IntegerCoordinate value)
        {
          myValue = value;
        }

        public IntegerCoordinate Coordinate
        {
          get { return myValue; }
        }

        public uint ComponentId
        {
          get { throw new NotImplementedException(); }
        }
      }
    }

    protected void DoTest(double min, double max, Action<CostContext> act)
    {
      var ctx = new CostContext();
      act(ctx);
      var me = new ME(new JVREvaluatorOptions(), ctx);
      var eMin = me.Compute(false);
      var eMax = me.Compute(true);
      
      
      Assert.AreEqual(min, eMin.Value, "min");
      Assert.AreEqual(max, eMax.Value, "max");
      Assert.That(min, Is.LessThanOrEqualTo(max));
    }

    private class ME
    {
      private readonly JVREvaluatorOptions myOpts;
      private readonly CostContext myContext;

      public ME(JVREvaluatorOptions opts, CostContext context)
      {
        myOpts = opts;
        myContext = context;
      }

      public ComputationResult Compute(bool isMin)
      {
        var e = new JVREvaluator<INode<IntegerCoordinate>>(
          myOpts, 
          myContext, 
          !isMin 
            ? (IMorseEvaluatorCost<INode<IntegerCoordinate>>) myContext 
            : new NegativeCost<INode<IntegerCoordinate>>(myContext)
            );
        var computationResult = e.Minimize();

        return !isMin ? computationResult : computationResult.Negative();
      }
    }
  }
}