using System;
using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  public class PointGraph
  {
    private readonly IFunction<double> myFunction;
    private readonly int myDim;
    private readonly double[] myEps;
    private readonly List<PointGraphNode> myNodes = new List<PointGraphNode>();

    public PointGraph(IFunction<double> function, double[] eps)
    {
      myFunction = function;
      myEps = eps;
      myDim = myFunction.Dimension;
    }

    public double[] Evaluate(PointGraphNode node)
    {
      if (node.PointY != null)
        return node.PointY;

      myFunction.Input = node.PointX;
      node.PointY = CreateArray();
      myFunction.Output = node.PointY;
      myFunction.Evaluate();

      return node.PointY;
    }

    private double[] CreateArray()
    {
      return new double[myDim];
    }

    private double[] Middle(double[] d1, double[] d2)
    {
      double[] result = CreateArray();
      for(int i=0; i<myDim; i++)
      {
        result[i] = (d1[i] + d2[i])/2.0;
      }
      return result;
    }

    public PointGraphEdge AddEdge(PointGraphNode n1, PointGraphNode n2)
    {
      n1.Edges.Add(n2);
      n2.Edges.Add(n1);
      return new PointGraphEdge(n1, n2);
    }

    public PointGraphNode CreateNodeCopy(params double[] data)
    {
      double[] d = CreateArray();
      Array.Copy(data, d, myDim);
      return CreateNodeNoCopy(d);
    }

    public PointGraphNode CreateNodeNoCopy(params double[] d)
    {
      var node = new PointGraphNode(d);
      myNodes.Add(node);
      return node;      
    }

    public IEnumerable<PointGraphNode> Nodes
    {
      get { return myNodes; }
    }

    public Pair<PointGraphNode, List<PointGraphEdge>> Subdivide(PointGraphNode n1, PointGraphNode n2)
    {
      var result = new List<PointGraphEdge>();
      n1.Edges.Remove(n2);
      n2.Edges.Remove(n1);

      PointGraphNode node = CreateNodeNoCopy(Middle(n1.PointX, n2.PointX));
      foreach (PointGraphNode mid in Hashset<PointGraphNode>.Intersect(n1.Edges, n2.Edges))
      {
        AddEdge(mid, node);
        result.Add(new PointGraphEdge(mid, node));
      }      

      AddEdge(n1, node);
      AddEdge(n2, node);
      result.Add(new PointGraphEdge(n1,node));
      result.Add(new PointGraphEdge(n2,node));

      return new Pair<PointGraphNode, List<PointGraphEdge>>(node, result);
    }

    public bool CheckDistance(PointGraphNode n1, PointGraphNode n2)
    {
      double[] d1 = Evaluate(n1);
      double[] d2 = Evaluate(n2);

      for(int i=0; i<myDim; i++)
      {
        if (Math.Abs(d1[i] - d2[i]) > myEps[i])
          return false;
      }
      return true;
    }

    public void ComputeDistance(PointGraphNode n1, PointGraphNode n2, double[] dist)
    {
      double[] d1 = Evaluate(n1);
      double[] d2 = Evaluate(n2);

      for (int i = 0; i < myDim; i++)
      {
        dist[i] = Math.Abs(d1[i] - d2[i]);
      }
    }
  }
}
