﻿using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Utils;

namespace DSIS.Graph.Morse.Howard
{
  public class HowardEvaluator<T>
  {
    private readonly double myEps;

    private readonly IMorseEvaluatorGraph<T> myGraphComponent;
    private readonly IMorseEvaluatorCost<T> myCost;
    private readonly List<IMorseEvaluatorPersist<T>> myPersist = new List<IMorseEvaluatorPersist<T>>();

    //TODO: Use graph data holder
    private readonly Dictionary<T, ContourNode> myNodes;
    
    public HowardEvaluator(HowardEvaluatorOptions opts, IMorseEvaluatorGraph<T> graphComponent, IMorseEvaluatorCost<T> cost)
    {
      myCost = cost;
      myNodes = new Dictionary<T, ContourNode>(graphComponent.Comparer);
      myEps = opts.Eps;
      myGraphComponent = graphComponent;
    }

    private ContourNode CreateNode(T node)
    {
      ContourNode gnode;
      if (!myNodes.TryGetValue(node, out gnode))
      {
        gnode = new ContourNode(node, myCost.Cost(node));
        myNodes.Add(node, gnode);
      }
      return gnode;
    }

    public ComputationResult<T> Minimize()
    {      
      foreach (var from in myGraphComponent.GetNodes().Select(CreateNode))
      {
        //Out implementation detail - all edges revieve same weight, computed from 'from' node
        //Implementation of this is simplified because of that
        var w_from_to = myCost.Cost(from.Node);
        from.D = w_from_to;
        from.π = CreateNode(myGraphComponent.GetNodes(from.Node).First());
      }

      //Main loop
      while(true)
      {
        var smallestLoop = Find_π_SmallestLoop();
        var λ = smallestLoop.First;
        var C = smallestLoop.Second;
        var s = C[0];

        //update paths to s
        BFS(s, q => q.D = q.π.D + q.Cost - λ);

        var result = Improve(λ);
        if (!result)
          return new ComputationResult<T>(λ, smallestLoop.Second.Select(x => x.Node).ToArray());
      }
    }

    private static void BFS(ContourNode start, Action<ContourNode> achieved)
    {
      var visited = new HashSet<ContourNode>();
      var queue = new Queue<ContourNode>();
      queue.Enqueue(start);
      while(queue.Count > 0)
      {
        var node = queue.Dequeue();
        if (visited.Contains(node)) continue;
        visited.Add(node);
        foreach (var πIncomingNode in node.π_IncomingNodes())
        {
          achieved(πIncomingNode);
          queue.Enqueue(πIncomingNode);
        }
      }
    }

    private bool Improve(double λ)
    {
      bool improved = false;
      foreach (var from in myGraphComponent.GetNodes().Select(CreateNode))
      {
        foreach (var to in myGraphComponent.GetNodes(from.Node).Select(CreateNode))
        {
          var p = to.D + from.Cost - λ;

          var δ = from.D - p;
          if (δ > myEps)
          {
            improved = true;
            from.D = p;
            from.π = to;
          }
        }
      }
      return improved;
    }

    private Pair<double, ContourNode[]> Find_π_SmallestLoop()
    {      
      double? λ_opt = null;
      IEnumerable<ContourNode> contour = EmptyArray<ContourNode>.Instance;

      foreach (var πLoop in πLoops())
      {
        var nodes = πLoop;
        var λ = Cost(nodes);
        if (λ_opt == null || λ < λ_opt)
        {
          λ_opt = λ;
          contour = nodes;
        }
      }

      return Pair.Of(λ_opt.Value, contour.ToArray());
    }

    private static double Cost(IEnumerable<ContourNode> contour)
    {
      double c = 0;
      double v = 0;
      foreach (var node in contour)
      {
        c++;
        v += node.Cost;
      }
      return v/c;
    }

    private static IEnumerable<ContourNode> πCycle(ContourNode root)
    {
      yield return root;
      for(var node = root.π; node != root; node = node.π)
      {
        yield return node;
      }
    }

    private IEnumerable<IEnumerable<ContourNode>> πLoops()
    {
      //Referemce comparer is OK here.
      var notVisited = new HashSet<ContourNode>(myNodes.Values);
      while(notVisited.Count > 0)
      {
        var root = notVisited.First();

        //Referemce comparer is OK here.
        var path = new HashSet<ContourNode>();

        for (var node = root; ; node = node.π)
        {
          if (path.Contains(node))
          {
            yield return πCycle(node);
            break;
          }

          //node is processed allready, thus it's ok to skip it
          if (!notVisited.Contains(node))
            break;

          path.Add(node);
          notVisited.Remove(node);
        }
      }
    }

    public class ContourNode
    {
      public readonly T Node;
      public readonly double Cost;
      public double D = double.MaxValue;
      private ContourNode my_π;
      private readonly HashSet<ContourNode> myIncomingNodes = new HashSet<ContourNode>();

      public ContourNode(T node, double node_cost)
      {
        Node = node;
        Cost = node_cost;
      }

      public ContourNode π
      {
        get
        {
          return my_π;
        }
        set
        {
          if (my_π != null)
            my_π.myIncomingNodes.Remove(this);
          my_π = value;
          my_π.myIncomingNodes.Add(this);
        }
      }

      public IEnumerable<ContourNode> π_IncomingNodes()
      {
        return myIncomingNodes;
      }

      public override string ToString()
      {
        return string.Format("{0} {1:F}", Node, Cost);
      }
    }

  }
}