using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Morse
{
  public abstract class MorseEvaluator<T,N>  
    where N : class
  {
    private readonly double myEps;

    private readonly IMorseEvaluatorGraph<N> myGraphComponent;
    private readonly List<IMorseEvaluatorPersist<N>> myPersist = new List<IMorseEvaluatorPersist<N>>();
   
    private IGraphDataHolder<ContourNode<N>,N> myNodes;
    private double myFactor;

    protected MorseEvaluator(MorseEvaluatorOptions opts, IMorseEvaluatorGraph<N> graphComponent)
    {
      myFactor = 0;

      myEps = opts.Eps;
      myGraphComponent = graphComponent;
    }

    public void AddPersist(IMorseEvaluatorPersist<N> persist)
    {
      myPersist.Add(persist);
    }

    protected abstract double Cost(N node);

    private double ContourCost(ContourNode<N> node)
    {
      int kV = 1;
      double r = node.Cost;
      ContourNode<N> n = node.Parent;

      var cutOff = myGraphComponent.Count + 5;
      
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

    private static void ToList(ContourNode<N> node, ICollection<N> list)
    {
      ContourNode<N> n = node.Parent;

      list.Add(n.Node);
      while (n != node)
      {
        list.Add(n.Node);
        n = n.Parent;
      }
    }

    private static bool Preceeds(ContourNode<N> root, ContourNode<N> i1, ContourNode<N> i2)
    {
      int cnt = 0;
      ContourNode<N> t = i2;
      while ((t != i1) && (cnt < 2))
      {
        if (t == root) cnt++;
        t = t.Parent;
      }

      return t == i1;
    }

    private ContourNode<N> Tree(ContourNode<N> rnode)
    {
      ResetType();

      var m = new List<ContourNode<N>>();
      double z = ContourCost(rnode);

      rnode.Value = 0;
      rnode.Type2 = NodeType.M1;
      m.Insert(0, rnode);

      ContourNode<N> n = rnode.Parent;
      ContourNode<N> p = rnode;

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
        ContourNode<N> node = m[0];
        m.RemoveAt(0);
        node.Type2 = NodeType.M0;

        foreach (var toNode in myGraphComponent.GetNodes(node.Node)) 
        {
          var to = myNodes.GetData(toNode);
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
              else
              {
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

    private ContourNode<N> DoCompute(ContourNode<N> node)
    {
      foreach (var persist in myPersist)
      {        
        persist.SaveGraph(myGraphComponent, x=>myNodes.GetData(x).Cost);
      }

      var pNode = node;
      while(node != null)
      {
        pNode = node;
        node = Tree(node);
      }

      return pNode;
    }

    private ContourNode<N> CreateNode(N node)
    {
      return myNodes.GetData(node);
    }

    private ContourNode<N> Init()
    {
      foreach (N node in myGraphComponent.GetNodes())
      {
        var gnode = CreateNode(node);
        ContourNode<N> minEdge = null;
        foreach (var edgeTo in myGraphComponent.GetNodes(node))
        {
          ContourNode<N> gedge = CreateNode(edgeTo);
          if (minEdge == null || minEdge.Cost > gedge.Cost)
          {
            minEdge = gedge;
          }
        }
        gnode.Parent = minEdge;
        minEdge.Incoming++;
      }

      foreach (var _node in myNodes.Values)
      {
        ContourNode<N> node = _node;
        while (node.Incoming == 0)
        {
          node.Incoming = -1; //mark as trash
          node = node.Parent;
          node.Incoming--;
        }
      }

      ContourNode<N> root = null;
      double rootZ = 0;
      foreach (var nde in myNodes.Values)
      {
        if (nde.Incoming > 0)
        {          
          double cst = nde.Cost;
          int kV = 1;
          ContourNode<N> t = nde.Parent;
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


    private static void CreateTreeInit(ContourNode<N> root)
    {
      var p = root;
      var q = root.Parent;
      while (q != root)
      {
        ContourNode<N> t = q.Parent;
        q.Parent = p;
        p = q;
        q = t;
      }
      q.Parent = p;
    }

    public ComputationResult<N> Compute(bool maximum)
    {
      using (myNodes = myGraphComponent.AllocDataHolder(node => new ContourNode<N>(node, myFactor * Cost(node))))
      {
        myFactor = maximum ? -1 : 1;

        ContourNode<N> extrema = Init();
        extrema = DoCompute(extrema);
        double answerValue = ContourCost(extrema);

        var list = new List<N>();
        ToList(extrema, list);
        return new ComputationResult<N>(myFactor*answerValue, list.AsReadOnly(), maximum);
      }
    }
  }
}