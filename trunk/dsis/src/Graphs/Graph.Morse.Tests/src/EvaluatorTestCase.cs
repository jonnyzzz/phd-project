using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Utils;
using JetBrains.Annotations;
using NUnit.Framework;

namespace DSIS.Graph.Morse.Tests
{
  [TestFixture]
  public abstract class EvaluatorTestCase
  {
    protected abstract IMorseEvaluator<T> CreateEvaluator<T>(IMorseEvaluatorCost<T> cost, IMorseEvaluatorGraph<T> graph);

    protected double Eps { get; set; }

    [SetUp]
    public virtual void SetUp()
    {
      Eps = 0.001;
    }
    
    protected void DoTest(double w, [CanBeNull] IEnumerable<int> cycle, Action<Builder<int>> builder)
    {
      var mi = new MorseInput<int>();
      builder(mi);

      //TODO: Assert strong component
      var ev = CreateEvaluator(mi, mi);

      var res = ev.Minimize();

      try
      {
        Assert.AreEqual(w, res.Value, Eps);

        if (cycle != null)
        {
          double cost = cycle.Sum(x => mi.Cost(x)) / cycle.Count();
          Assert.AreEqual(cost, w, Eps, "Assertion contour should have right computed mean value");
          try
          {
            Assert.AreEqual(cycle.Count(), res.Contour.Count(), "Set count shuold be equal");
            var cycleNodes = new HashSet<int>(cycle);
            var contuNodes = new HashSet<int>(res.Contour);

            Assert.IsTrue(cycleNodes.IsSubsetOf(contuNodes) && contuNodes.IsSubsetOf(cycleNodes));
          }
          catch (Exception e)
          {
            Console.Out.WriteLine("expect contour = {0}", cycle.JoinString(", "));
            throw new Exception(e.Message, e);
          }

          Assert.IsFalse(res.Count == 0, "Count > 0");
          Assert.IsFalse(res.Contour.IsEmpty());
          Assert.AreEqual(res.Count, res.Contour.Count);

          var prevNode = res.Contour.LastOrDefault();
          foreach (var node in res.Contour)
          {
            Assert.IsTrue(mi.GetNodes(prevNode).Contains(node), "Found contour should be in graph: {0} -> {1}", prevNode, node);
            prevNode = node;
          }
        }
      } catch (Exception e)
      {
        Console.Out.WriteLine("actual value = {0}", res.Value);
        Console.Out.WriteLine("actual contour = {0}", res.Contour.JoinString(", "));
        throw new Exception(e.Message, e);
      }
    }

    protected interface Builder<in T>
    {
      void SetWeight(T node, double w);
      void SetEdge(T from, T to);

      void Node(T id, double w, params T[] to);
      void Node(T id, double w, IEnumerable<T> tos);
    }

    private class MorseInput<T> : IMorseEvaluatorGraph<T>, IMorseEvaluatorCost<T>, Builder<T>
    {
      private readonly MultiDictionary<T, T> myGraph = new MultiDictionary<T, T>(EqualityComparerFactory<T>.GetComparer());
      private readonly Dictionary<T, double> myWeight = new Dictionary<T, double>();

      public void Node(T id, double w, IEnumerable<T> to)
      {
        Node(id, w, to.ToArray());
      }

      public void Node(T id, double w, params T[] to)
      {
        SetWeight(id, w);
        foreach (var t in to)
          SetEdge(id, t);
      }

      public void SetWeight(T node, double v)
      {
        myWeight[node] = v;
      }

      public void SetEdge(T from, T to)
      {
        myGraph.AddValue(from, to);
      }

      public IEnumerable<T> GetNodes(T node)
      {
        return new HashSet<T>(myGraph.GetValues(node));
      }

      public IEnumerable<T> GetNodes()
      {
        return myGraph.Keys;
      }

      public IEqualityComparer<T> Comparer
      {
        get { return EqualityComparerFactory<T>.GetComparer(); }
      }

      public double Cost(T t)
      {
        return myWeight[t];
      }
    }
  }
}