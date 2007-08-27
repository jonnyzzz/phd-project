using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class JVRMeasure<T>
    where T : ICellCoordinate<T>
  {
    protected Dictionary<NodePair<T>, double> myEdges = new Dictionary<NodePair<T>, double>(EqualityComparerFactory<NodePair<T>>.GetComparer());
    protected Dictionary<NodePair<T>, double> myBackEdges = new Dictionary<NodePair<T>, double>(EqualityComparerFactory<NodePair<T>>.GetComparer());

    private readonly IGraph<T> myGraph;
    private readonly IGraphStrongComponents<T> myComponents;

    protected double myNorm;

    public JVRMeasure(IGraph<T> graph, IGraphStrongComponents<T> components)
    {
      myGraph = graph;
      myComponents = components;
    }

    protected void FillGraph()
    {
      myNorm = 0;
      foreach (INode<T> node in myGraph.Nodes)
      {
        if (myComponents.GetNodeComponent(node) == null)
          continue;

        T nodeCoordinate = node.Coordinate;
        int nodeHash = NodePair<T>.HashValue(nodeCoordinate);
        
        double weight = 0;
        foreach (INode<T> edge in myGraph.GetEdges(node))
        {
          T edgeCoordinate = edge.Coordinate;
          int edgeHash = NodePair<T>.HashValue(edgeCoordinate);

          myEdges.Add(new NodePair<T>(nodeCoordinate, nodeHash, edgeCoordinate, edgeHash),  1);
          myBackEdges.Add(new NodePair<T>(edgeCoordinate, edgeHash, nodeCoordinate, nodeHash), 1);
          weight += 1;
        }
        
        myNorm += weight;
      }      
    }

    protected void Norm()
    {
      double factor = myNorm;
      myEdges = Divide(myEdges, factor);
      myBackEdges = Divide(myBackEdges, factor);
      myNorm = 1;
    }

    private static Dictionary<NodePair<T>, double> Divide(Dictionary<NodePair<T>, double> input, double div)
    {
      Dictionary<NodePair<T>, double> ret = new Dictionary<NodePair<T>, double>(input.Comparer);
      foreach (KeyValuePair<NodePair<T>, double> pair in input)
      {
        ret.Add(pair.Key, pair.Value / div);
      }
      return ret;
    }

    private double ComputeWeight(IDictionary<NodePair<T>, double> nodes, INode<T> node)
    {
      double w = 0;
      T nodeCoordinates = node.Coordinate;
      int nodeHash = NodePair<T>.HashValue(nodeCoordinates);

      foreach (INode<T> edges in myGraph.GetEdges(node))
      {
        w += nodes[new NodePair<T>(nodeCoordinates, nodeHash, edges.Coordinate)];
      }
      return w;
    }
    
    private void MultiplyWeight(IDictionary<NodePair<T>, double> nodes, INode<T> node, double factor)
    {
      T nodeCoordinates = node.Coordinate;
      int nodeHash = NodePair<T>.HashValue(nodeCoordinates);

      foreach (INode<T> edges in myGraph.GetEdges(node))
      {
        NodePair<T> key = new NodePair<T>(nodeCoordinates, nodeHash, edges.Coordinate);
        double t = nodes[key];
        myNorm -= t;
        t *= factor;
        nodes[key] = t;
        myNorm += t;
      }
    }

    protected void Iterate()
    {
      const double EPS = 1e-2;

      foreach (INode<T> node in myGraph.Nodes)
      {
        double incomeing = ComputeWeight(myBackEdges, node);
        double outgoing  = ComputeWeight(myEdges, node);

        if (Math.Abs(incomeing - outgoing) <= EPS)
          continue;

        MultiplyWeight(myBackEdges, node, Math.Sqrt(incomeing / outgoing));
        MultiplyWeight(myEdges, node, Math.Sqrt(outgoing / incomeing));               
      }      
    }
  }
}
