using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Utils;

namespace DSIS.Graph.Morse.Howard
{
  public class HowardEvaluator<T> : MorseEvaluatorBase<T, HowardEvaluator<T>.ContourNode>, IMorseEvaluator<T>
  {
    private readonly double myEps;
    public HowardEvaluator(HowardEvaluatorOptions opts, IMorseEvaluatorGraph<T> graphComponent, IMorseEvaluatorCost<T> cost)
      : base(graphComponent, cost, (t,v) => new ContourNode(t, v))
    {
      myEps = opts.Eps;
    }

    protected override ComputationResult<T> MinimizeInternal()
    { 
      foreach (var from in Nodes)
      {
        //Out implementation detail - all edges revieve same weight, computed from 'from' node
        //Implementation of this is simplified because of that
        var w_from_to = from.Cost;
        from.D = w_from_to;
        from.π = NodesFrom(from.Node).First();
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
      foreach (var from in Nodes)
      {
        foreach (var to in NodesFrom(from.Node))
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

      πLoops(πLoop =>
               {
                 var nodes = πLoop;
                 var λ = ComputeCost(nodes);
                 if (λ_opt == null || λ < λ_opt)
                 {
                   λ_opt = λ;
                   contour = nodes;
                 }
               });

      return Pair.Of(λ_opt.Value, contour.ToArray());
    }

    private static double ComputeCost(IEnumerable<ContourNode> contour)
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
      var list = new List<ContourNode>{root};      
      for(var node = root.π; node != root; node = node.π)
      {
        list.Add(node);
      }
      return list.ToArray();
    }

    private void πLoops(Action<IEnumerable<ContourNode>> loopCallback)
    {
      //Referemce comparer is OK here.      
      var visited = new HashSet<ContourNode>();
      foreach (var root in Nodes)
      {
        if (visited.Contains(root)) continue;

        //Referemce comparer is OK here.
        var path = new HashSet<ContourNode>();

        for (var node = root; ; node = node.π)
        {
          if (path.Contains(node))
          {
            //Node contained in path => node contained in visited
            loopCallback(πCycle(node));
            break;
          }

          //node is processed allready, thus it's ok to skip it
          if (visited.Contains(node))
            break;

          path.Add(node);
          visited.Add(node);
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