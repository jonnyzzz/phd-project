using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Morse
{
  public class MorseEvaluatorOptions
  {
    public double Eps { get; set; }

    public MorseEvaluatorOptions()
    {
      Eps = 1e-8;
    }
  }

  public abstract class MorseEvaluator<T> where T : ICellCoordinate
  {
    private readonly double EPS;

    private readonly IStrongComponentInfo[] myComponentInfos;
    private readonly IGraphStrongComponents<T> myComponents;
    //TODO: Use graph data holder
    private readonly Dictionary<INode<T>, ContourNode<T>> myNodes;
    private double myFactor;

    protected MorseEvaluator(MorseEvaluatorOptions opts, IGraphStrongComponents<T> components, IStrongComponentInfo comp)
    {
      myComponentInfos = new[] {comp};
      myComponents = components;
      myNodes = new Dictionary<INode<T>, ContourNode<T>>(EqualityComparerFactory<INode<T>>.GetComparer());
      myFactor = 0;

      EPS = opts.Eps;
    }

    protected abstract double Cost(INode<T> node);

    private static double ContourCost(ContourNode<T> node)
    {
      int kV = 1;
      double r = node.NodeCost;
      ContourNode<T> n = node.Next;

      while (n != node)
      {
        kV++;
        r += n.NodeCost;
        n = n.Next;
      }
      return r/kV;
    }

    private static void ToList(ContourNode<T> node, ICollection<INode<T>> list)
    {
      ContourNode<T> n = node.Next;

      list.Add(n.Node);
      while (n != node)
      {
        list.Add(n.Node);
        n = n.Next;
      }
    }

    private static bool Preceeds(ContourNode<T> root, ContourNode<T> i1, ContourNode<T> i2)
    {
      int cnt = 0;
      ContourNode<T> t = i2;
      while ((t != i1) && (cnt < 2))
      {
        if (t == root) cnt++;
        t = t.Next;
      }

      return t == i1;
    }

    private void DebugDump(TextWriter tw)
    {
      int i = 0;
      var nodes = new Dictionary<INode<T>, int>();
      foreach (var node in myNodes)
      {
        nodes[node.Key] = i;
        tw.WriteLine("ctx.AddCost({0},{1});", i, node.Value.NodeCost.ToString(CultureInfo.GetCultureInfo("en-US")));
        i++;
      }

      tw.WriteLine();
      foreach (var node in nodes.Keys)
      {
        foreach (var to in myComponents.GetEdgesWithFilteredEdges(node, myComponentInfos))
        {
          tw.WriteLine("ctx.AddEdge({0}, {1});", nodes[node], nodes[to]);
        }
      }
    } 

    private bool Tree(ContourNode<T> rnode)
    {
      ResetType();

      var m = new List<ContourNode<T>>();
      double z = ContourCost(rnode);

      rnode.Value = 0;
      rnode.Type2 = NodeType.M1;
      m.Insert(0, rnode);

      ContourNode<T> n = rnode.Next;
      ContourNode<T> p = rnode;

      while (n != rnode)
      {
        m.Insert(0, n);
        n.Type2 = NodeType.M1;
        n.Value = p.Value - p.NodeCost + z;
        p = n;
        n = n.Next;
      }
//      p.Next = null;

      while (m.Count > 0)
      {
        ContourNode<T> node = m[0];
        m.RemoveAt(0);
        node.Type2 = NodeType.M0;

        foreach (var toNode in myComponents.GetEdgesWithFilteredEdges(node.Node, myComponentInfos))
        {
          var to = myNodes[toNode];
          var w = node.Value + to.NodeCost - z;

          if (to.Type2 == NodeType.M2)
          {
            m.Add(to);

            to.Type2 = NodeType.M1;
            to.Value = w;
            to.Next = node;
          }
          else
          {
            if ((w - EPS) < to.Value)
            {
              if (Preceeds(rnode, to, node))
              {
                to.Next = node;
                return false;
              }

              if (Preceeds(rnode, node, to))
              {
                to.Value = w;
                to.Next = node;
                if (to.Type2 == NodeType.M0)
                {
                  to.Type2 = NodeType.M1;
                  m.Insert(0, to);
                }
              }
            }
          }
        }
      }
      return true; //contour is minimal.
    }

    private void ResetType()
    {
      foreach (var node in myNodes.Values)
      {
        node.Type2 = NodeType.M2;
      }
    }

    private ContourNode<T> DoCompute(ContourNode<T> node)
    {
      var file = string.Format(@"e:\data{0}.txt", DateTime.Now.ToFileTime());
      using(TextWriter tw = File.CreateText(file))
      {
        DebugDump(tw);
      }

      while (!Tree(node))
      {
      }

      File.Delete(file);
      return node;
    }

    private ContourNode<T> CreateNode(INode<T> node)
    {
      ContourNode<T> gnode;
      if (!myNodes.TryGetValue(node, out gnode))
      {
        gnode = new ContourNode<T>(node, myFactor*Cost(node));
        myNodes[node] = gnode;
      }
      return gnode;
    }

    private ContourNode<T> Init()
    {
      foreach (INode<T> node in myComponents.GetNodes(myComponentInfos))
      {
        var gnode = CreateNode(node);
        ContourNode<T> minEdge = null;
        foreach (var edgeTo in myComponents.GetEdgesWithFilteredEdges(node, myComponentInfos))
        {
          ContourNode<T> gedge = CreateNode(edgeTo);
          if (minEdge == null || minEdge.NodeCost > gedge.NodeCost)
          {
            minEdge = gedge;
          }
        }
        gnode.Next = minEdge;
        minEdge.Incoming++;
      }

      foreach (var _node in myNodes.Values)
      {
        ContourNode<T> node = _node;
        while (node.Incoming == 0)
        {
          node.Incoming = -1; //mark as trash
          node = node.Next;
          node.Incoming--;
        }
      }

      ContourNode<T> root = null;
      double rootZ = 0;
      foreach (var nde in myNodes.Values)
      {
        if (nde.Incoming > 0)
        {          
          double cst = nde.NodeCost;
          int kV = 1;
          ContourNode<T> t = nde.Next;
          while (t != nde)
          {
            cst += t.NodeCost;
            kV++;
            t.Incoming = 0;
            t = t.Next;
          }

          cst /= kV;
          if (root == null || rootZ > cst)
          {
            root = nde;
            rootZ = cst;
          }
        }
        nde.Incoming = 0;
      }

      CreateTreeInit(root);

      return root;
    }

    private static void CreateTreeInit(ContourNode<T> root)
    {
      var p = root;
      var q = root.Next;
      while (q != root)
      {
        ContourNode<T> t = q.Next;
        q.Next = p;
        p = q;
        q = t;
      }
      q.Next = p;
    }

    public ComputationResult<T> Compute(bool maximum)
    {
      myNodes.Clear();
      myFactor = maximum ? -1 : 1;

      ContourNode<T> extrema = Init();
      extrema = DoCompute(extrema);
      double answerValue = ContourCost(extrema);

      var list = new List<INode<T>>();      
      ToList(extrema, list);
      return new ComputationResult<T>(myFactor * answerValue, list.AsReadOnly(), maximum);
    }
  }
}