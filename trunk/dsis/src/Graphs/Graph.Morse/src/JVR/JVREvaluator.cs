using System;
using System.Collections.Generic;
using System.Linq;

namespace DSIS.Graph.Morse.JVR
{
  public class JVREvaluator<T> : IMorseEvaluator<T>
  {
    private readonly double myEps;

    private readonly IMorseEvaluatorGraph<T> myGraphComponent;
    private readonly IMorseEvaluatorCost<T> myCost;
    private readonly List<IMorseEvaluatorPersist<T>> myPersist = new List<IMorseEvaluatorPersist<T>>();

    //TODO: Use graph data holder
    private readonly Dictionary<T, ContourNode<T>> myNodes;

    public JVREvaluator(JVREvaluatorOptions opts, IMorseEvaluatorGraph<T> graphComponent, IMorseEvaluatorCost<T> cost)
    {
      myCost = cost;
      myNodes = new Dictionary<T, ContourNode<T>>(graphComponent.Comparer);
      myEps = opts.Eps;
      myGraphComponent = graphComponent;
    }

    public void AddPersist(IMorseEvaluatorPersist<T> persist)
    {
      myPersist.Add(persist);
    }

    private double ContourCost(ContourNode<T> node)
    {
      int kV = 1;
      double r = node.Cost;
      ContourNode<T> n = node.Parent;

      var cutOff = myNodes.Count + 5;
      
      while (n != node)
      {
        kV++;
        r += n.Cost;
        n = n.Parent;

        if (kV > cutOff)
        {
          throw new ArgumentException("Mallformed loop is used.");
        }
      }
      return r/kV;
    }

    private static List<T> ToList(ContourNode<T> node)
    {
      ContourNode<T> n = node.Parent;
      var list = new List<T> {node.Node};
      while (n != node)
      {
        list.Add(n.Node);
        n = n.Parent;
      }
      list.Reverse();
      return list;
    }

    //TODO: Check!
    private static bool Preceeds(ContourNode<T> root, ContourNode<T> i1, ContourNode<T> i2)
    {
      int cnt = 0;
      ContourNode<T> t = i2;
      while ((t != i1) && (cnt < 2))
      {
        if (t == root) cnt++;
        t = t.Parent;
      }

      return t == i1;
    }

    private ContourNode<T> Tree(ContourNode<T> rnode)
    {
      ResetType();

      var m = new List<ContourNode<T>>();
      double z = ContourCost(rnode);

      rnode.Value = 0;
      rnode.Type2 = NodeType.M1;
      m.Insert(0, rnode);

      ContourNode<T> n = rnode.Parent;
      ContourNode<T> p = rnode;

      while (n != rnode)
      {
        m.Insert(0, n);
        n.Type2 = NodeType.M1;
        n.Value = p.Value - p.Cost + z;
        p = n;
        n = n.Parent;
      }
      //Note: Here we do not assign p.Parent = null in order to check 
      //Note: Node preceed 
      //p.Parent = null;

      while (m.Count > 0)
      {
        ContourNode<T> node = m[0];
        m.RemoveAt(0);
        node.Type2 = NodeType.M0;

        foreach (var toNode in myGraphComponent.GetNodes(node.Node)) 
        {
          var to = myNodes[toNode];
          var w = node.Value + to.Cost - z;

          if (to.Type2 == NodeType.M2)
          {
            m.Add(to);

            to.Type2 = NodeType.M1;
            to.Value = w;
            to.Parent = node;
          }
          else
          {
            if ((w + myEps) < to.Value)
            {
              if (Preceeds(rnode, to, node))
              {
                to.Parent = node;
                return to;
              }
              
              to.Value = w;
              to.Parent = node;
              if (to.Type2 == NodeType.M0)
              {
                to.Type2 = NodeType.M1;
                m.Insert(0, to);
              }
            }
          }
        }
      }
      return null; //contour is minimal.
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
      foreach (var persist in myPersist)
      {        
        persist.SaveGraph(myGraphComponent, x=>myNodes[x].Cost);
      }

      var pNode = node;
      while(node != null)
      {
        pNode = node;
        node = Tree(node);
      }

      return pNode;
    }

    private ContourNode<T> CreateNode(T node)
    {
      ContourNode<T> gnode;
      if (!myNodes.TryGetValue(node, out gnode))
      {
        gnode = new ContourNode<T>(node, myCost.Cost(node));
        myNodes.Add(node, gnode);
      }
      return gnode;
    }

    private ContourNode<T> Init()
    {
      foreach (T node in myGraphComponent.GetNodes())
      {
        var gnode = CreateNode(node);
        ContourNode<T> minEdge = null;
        foreach (var gedge in myGraphComponent.GetNodes(node).Select(CreateNode))
        {
          if (minEdge == null || minEdge.Cost > gedge.Cost)
            minEdge = gedge;
        }

        gnode.Parent = minEdge;
        
        if (minEdge != null)
          minEdge.Incoming++;
      }

      foreach (var _node in myNodes.Values)
      {
        ContourNode<T> node = _node;
        while (node.Incoming == 0)
        {
          node.Incoming = -1; //mark as trash
          node = node.Parent;
          node.Incoming--;
        }
      }

      ContourNode<T> root = null;
      double rootZ = 0;
      foreach (var nde in myNodes.Values)
      {
        if (nde.Incoming > 0)
        {          
          double cst = nde.Cost;
          int kV = 1;
          ContourNode<T> t = nde.Parent;
          while (t != nde)
          {
            cst += t.Cost;
            kV++;
            t.Incoming = 0;
            t = t.Parent;
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
      var q = root.Parent;
      while (q != root)
      {
        ContourNode<T> t = q.Parent;
        q.Parent = p;
        p = q;
        q = t;
      }
      q.Parent = p;
    }

    public ComputationResult<T> Minimize()
    {
      myNodes.Clear();

      ContourNode<T> extrema = Init();
      extrema = DoCompute(extrema);
      double answerValue = ContourCost(extrema);

      var list = ToList(extrema);
      return new ComputationResult<T>(answerValue, list.ToArray());
    }
  }
}