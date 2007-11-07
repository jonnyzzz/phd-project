using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph.Abstract;
using DSIS.Utils;

namespace DSIS.Graph.Morse
{
  public abstract class MorseEvaluator<T> where T : ICellCoordinate<T>
  {
    private const double EPS = 1e-8;

    private readonly IStrongComponentInfo[] myComponentInfos;
    private readonly IGraphStrongComponents<T> myComponents;
    private readonly Dictionary<INode<T>, ContourNode<T>> myNodes;
    private double myFactor;


    public MorseEvaluator(IGraphStrongComponents<T> components, IStrongComponentInfo comp)
    {
      myComponentInfos = new IStrongComponentInfo[] {comp};
      myComponents = components;
      myNodes = new Dictionary<INode<T>, ContourNode<T>>(EqualityComparerFactory<INode<T>>.GetComparer());
      myFactor = 0;
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

    private static bool IsSub(ContourNode<T> root, ContourNode<T> i1, ContourNode<T> i2)
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

    private static bool Preceeds(ContourNode<T> root, ContourNode<T> i1, ContourNode<T> i2)
    {
      return IsSub(root, i1, i2);
    }

    private bool Tree(ContourNode<T> rnode)
    {
      foreach (ContourNode<T> node in myNodes.Values)
      {
        node.Type = NodeType.M2;
      }

      List<ContourNode<T>> m = new List<ContourNode<T>>();
      double z = ContourCost(rnode);

      rnode.Value = 0;
      rnode.Type = NodeType.M1;
      m.Insert(0, rnode);

      ContourNode<T> n = rnode.Next;
      ContourNode<T> p = rnode;

      while (n != rnode)
      {
        m.Insert(0, n);
        n.Type = NodeType.M1;
        n.Value = p.Value - p.NodeCost + z;
        p = n;
        n = n.Next;
      }
      //p->Next = NULL;

      while (m.Count > 0)
      {
        ContourNode<T> node = m[0];
        m.RemoveAt(0);
        node.Type = NodeType.M0;

        foreach (INode<T> toNode in myComponents.GetEdgesWithFilteredEdges(node.Node, myComponentInfos))
        {
          ContourNode<T> to = myNodes[toNode];
          double w = node.Value + to.NodeCost - z;

          if (to.Type == NodeType.M2)
          {
            m.Add(to);

            to.Type = NodeType.M1;
            to.Value = w;
            to.Next = node;
          }
          else
          {
            //ASSERT(to.Type == NodeType.M0 || to.Type == NodeType.M1);

            if ((w + EPS) < to.Value)
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
                if (to.Type == NodeType.M0)
                {
                  to.Type = NodeType.M1;
                  m.Insert(0, to);
                }
              }
            }
            else
            {
              //to->Type = M0;
            }
          }
        }
      }
      return true; //contour is minimal.
    }

    private ContourNode<T> DoCompute(ContourNode<T> node)
    {
      while (!Tree(node))
      {
      }
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
        ContourNode<T> gnode = CreateNode(node);
        ContourNode<T> minEdge = null;
        foreach (INode<T> edgeTo in myComponents.GetEdgesWithFilteredEdges(node, myComponentInfos))
        {
          ContourNode<T> gedge = CreateNode(edgeTo);
          if (minEdge == null || minEdge.NodeCost > gedge.NodeCost)
          {
            minEdge = gedge;
          }
        }
        gnode.Next = minEdge;
        minEdge.Type++;
      }

      foreach (ContourNode<T> _node in myNodes.Values)
      {
        ContourNode<T> node = _node;
        while (node.Type == NodeType.M2)
        {
          node.Type = NodeType.M1; //mark as trash
          node = node.Next;
          node.Type--;
        }
      }

      ContourNode<T> root = null;
      double rootZ = 1.7E+300;
      foreach (ContourNode<T> nde in myNodes.Values)
      {
        if (nde.Type > 0)
        {
          nde.Type = NodeType.M2;

          double cst = nde.NodeCost;
          int kV = 1;
          ContourNode<T> t = nde.Next;
          while (t != nde)
          {
            cst += t.NodeCost;
            kV++;
            t.Type = NodeType.M2;
            t = t.Next;
          }

          cst /= kV;
          if (root == null || rootZ > cst)
          {
            root = nde;
            rootZ = cst;
          }
        }
        nde.Type = NodeType.M2;
      }

      CreateTreeInit(root);

      return root;
    }

    private static void CreateTreeInit(ContourNode<T> root)
    {
      ContourNode<T> p = root;
      ContourNode<T> q = root.Next;
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

      List<INode<T>> list = new List<INode<T>>();
      ContourNode<T> n = extrema.Next;
      while (extrema != n)
      {
        list.Add(n.Node);
        extrema = n.Next;
      }
      return new ComputationResult<T>(myFactor * answerValue, list.AsReadOnly());
    }
  }
}