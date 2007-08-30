using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

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

    public void Norm()
    {
      myHashHolder.Normalize();      
    }

    public void Iterate(double precision)
    {     
      double normEps = precision * 1e-4;
      while(true)
      {
        T node = myHashHolder.NextNode();
        
        double incoming = myBackEdges.ComputeWeight(node);
        double outgoing  = myEdges.ComputeWeight(node);

        if (Math.Abs(incoming - outgoing) <= precision)
          break;

        double a = Math.Sqrt(outgoing / incoming);
        double b = Math.Sqrt(incoming / outgoing);

        if (a <= normEps || b <= normEps)
        {
          myHashHolder.Normalize();
          continue;
        }

        myBackEdges.MultiplyWeight(node, a);        
        myEdges.MultiplyWeight(node, b);
      }      
    }

    public EntropyEvaluator<T, JVRPair<T>> CreateEvaluator()
    {
      return myHashHolder.CreateEvaluator();
    }    
  }
}
