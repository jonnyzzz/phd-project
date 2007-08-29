using System;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class JVRMeasure<T>
    where T : ICellCoordinate<T>
  {
    protected HashHolder<T> myHashHolder;
    protected ArcDirection<T> myEdges;
    protected ArcDirection<T> myBackEdges;

    private readonly IGraph<T> myGraph;
    private readonly IGraphStrongComponents<T> myComponents;
    
    public JVRMeasure(IGraph<T> graph, IGraphStrongComponents<T> components)
    {
      myHashHolder = new HashHolder<T>();
      myBackEdges = new InverseArcDirection<T>(myHashHolder);
      myEdges = new StraitArcDirection<T>(myHashHolder);

      myGraph = graph;
      myComponents = components;
    }

    private bool VisitNode(INode<T> node)
    {
      return myComponents.GetNodeComponent(node) != null;
    }

    protected void FillGraph()
    {
      foreach (INode<T> node in myGraph.Nodes)
      {
        if (!VisitNode(node))
          continue;

        T nodeCoordinate = node.Coordinate;
        int nodeHash = JVRPair<T>.HashValue(nodeCoordinate);
        
        double weight = 0;
        foreach (INode<T> edge in myGraph.GetEdges(node))
        {
          if (!VisitNode(edge))
            continue;

          T edgeCoordinate = edge.Coordinate;
          int edgeHash = JVRPair<T>.HashValue(edgeCoordinate);

          JVRPair<T> key = new JVRPair<T>(nodeCoordinate, nodeHash, edgeCoordinate, edgeHash);
          myHashHolder.Add(key,  1);
          
          myEdges.Add(key);
          myBackEdges.Add(key);

          weight += 1;
        }
      }      
    }

    protected void Norm()
    {
      myHashHolder.Normalize();      
    }
    
    protected void Iterate()
    {
      const double EPS = 1e-2;

      foreach (INode<T> node in myGraph.Nodes)
      {
        if (!VisitNode(node))
          continue;

        double incoming = myBackEdges.ComputeWeight(node);
        double outgoing  = myEdges.ComputeWeight(node);

        if (Math.Abs(incoming - outgoing) <= EPS)
          continue;

        myBackEdges.MultiplyWeight(node, Math.Sqrt(incoming / outgoing));
        myEdges.MultiplyWeight(node, Math.Sqrt(outgoing / incoming));               
      }      
    }

    public void Entropy(IEntropyListener<T> listener)
    {      
      myHashHolder.ComputeEntropy(listener);
    }
  }
}
