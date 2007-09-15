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

    public void FillGraph()
    {
      foreach (INode<T> node in myGraph.Nodes)
      {
        if (!VisitNode(node))
          continue;

        T nodeCoordinate = node.Coordinate;
        int nodeHash = JVRPair<T>.HashValue(nodeCoordinate);
        
        foreach (INode<T> edge in myGraph.GetEdges(node))
        {
          if (!VisitNode(edge))
            continue;

          JVRPair<T> key = new JVRPair<T>(nodeCoordinate, nodeHash, edge.Coordinate);
          myHashHolder.Add(key,  1);
          
          myEdges.Add(key);
          myBackEdges.Add(key);
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
      const double maxValue = 3;

      while(true)
      {
        T node = myHashHolder.NextNode();
        
        double incoming = myBackEdges.ComputeWeight(node);
        double outgoing = myEdges.ComputeWeight(node);

        if (incoming >= maxValue || outgoing >= maxValue || incoming <= normEps || outgoing <= normEps)
        {
          myHashHolder.Normalize();
          continue;
        }

        if (Math.Abs(incoming - outgoing) <= precision)
          break;

        double a = Math.Sqrt(outgoing) / Math.Sqrt(incoming);
        double b = Math.Sqrt(incoming) / Math.Sqrt(outgoing);

        if (IsInvalid(a) || IsInvalid(b))
        {
          a = 0;
          b = 0;
        }
          
        if (incoming *  a <= normEps || outgoing * b <= normEps)
        {
          myHashHolder.Normalize();
          continue;
        }

        myBackEdges.MultiplyWeight(node, a);        
        myEdges.MultiplyWeight(node, b);
      
        Norm();
      }      
    }

    private static bool IsInvalid(double a)
    {
      return double.IsNaN(a) || double.IsInfinity(a);
    }

    public EntropyEvaluator<T, JVRPair<T>> CreateEvaluator()
    {
      return myHashHolder.CreateEvaluator();
    }    
  }
}
