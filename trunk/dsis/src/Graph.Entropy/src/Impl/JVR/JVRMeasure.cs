using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  //todo: Store edges in node to throw away dictionary usage!
  public class JVRMeasure<T>
    where T : ICellCoordinate
  {
    protected HashHolder<T> myHashHolder;
    protected ArcDirection<T> myStraitEdges;
    protected ArcDirection<T> myBackEdges;

    private readonly IGraph<T> myGraph;
    private readonly IGraphStrongComponents<T> myComponents;

    public JVRMeasure(IGraph<T> graph, IGraphStrongComponents<T> components)
    {
      myHashHolder = new HashHolder<T>();
      myBackEdges = new InverseArcDirection<T>(myHashHolder);
      myStraitEdges = new StraitArcDirection<T>(myHashHolder);

      myGraph = graph;
      myComponents = components;
    }

    private bool VisitNode(INode<T> node)
    {
      return myComponents.GetNodeComponent(node) != null;
    }

    public void FillGraph()
    {
      using (ItemRebuildCookie<T> cookie = myHashHolder.RebuildCookie())
      {
        foreach (INode<T> node in myGraph.Nodes)
        {
          if (!VisitNode(node))
            continue;

          JVRPair<T>.JVRPairFactory factory = JVRPair<T>.Factory(node.Coordinate);
          
          foreach (INode<T> edge in myGraph.GetEdges(node))
          {
            if (!VisitNode(edge))
              continue;

            JVRPair<T> key = factory.Create(edge.Coordinate);
            
            myStraitEdges.Add(key);
            myBackEdges.Add(key);

            cookie.SetItem(key, 1);
          }
        }
      }
    }

    protected void Norm()
    {
      myHashHolder.Normalize();
    }

    public void Iterate(double precision)
    {
      double normEps = precision*1e-4;
      const double maxValue = 3;

      while (true)
      {
        T node = myHashHolder.NextNode();

        double incoming = myBackEdges.ComputeWeight(node);
        double outgoing = myStraitEdges.ComputeWeight(node);
        bool needNorm = false;

        needNorm |= (incoming >= maxValue || outgoing >= maxValue || incoming <= normEps || outgoing <= normEps);

        if (Math.Abs(incoming - outgoing) <= precision)
          break;

        double a = Math.Sqrt(outgoing)/Math.Sqrt(incoming);
        double b = Math.Sqrt(incoming)/Math.Sqrt(outgoing);

        if (IsInvalid(a) || IsInvalid(b))
        {
          a = 0;
          b = 0;
        }

        needNorm |= (incoming*a <= normEps || outgoing*b <= normEps);

        using (ItemUpdateCookie<T> cookie = myHashHolder.UpdateCookie(myStraitEdges, myBackEdges))
        {
          myBackEdges.MultiplyWeight(cookie, node, a);
          myStraitEdges.MultiplyWeight(cookie, node, b);
        }

        if (needNorm)
          Norm();
      }
    }

    private static bool IsInvalid(double a)
    {
      return double.IsNaN(a) || double.IsInfinity(a);
    }

    public IGraphMeasure<T> CreateEvaluator()
    {
      return myHashHolder.CreateEvaluator();
    }
  }
}