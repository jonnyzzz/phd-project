using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  //todo: Store edges in node to throw away dictionary usage!
  public class JVRMeasure<T>
    where T : ICellCoordinate
  {
    private readonly JVRMeasureOptions myOptions;
    protected readonly HashHolder<T> myHashHolder;
    private readonly ArcDirection<T> myStraitEdges;
    private readonly ArcDirection<T> myBackEdges;

    private readonly double myCellVolume;

    private readonly IGraph<T> myGraph;
    private readonly IGraphStrongComponents<T> myComponents;

    public JVRMeasure(IGraph<T> graph, IGraphStrongComponents<T> components, JVRMeasureOptions opts)
    {
      myOptions = opts;
      myHashHolder = new HashHolder<T>(graph.CoordinateSystem);
      myBackEdges = new InverseArcDirection<T>(myHashHolder);
      myStraitEdges = new StraitArcDirection<T>(myHashHolder);

      myGraph = graph;
      myComponents = components;

      myCellVolume = ((IIntegerCoordinateSystem) myGraph.CoordinateSystem).CellSize.FoldLeft(1.0, (x, v) => x*v);
    }

    private bool VisitNode(INode<T> node)
    {
      return myComponents.GetNodeComponent(node) != null;
    }

    public void FillGraph()
    {
      using (var cookie = myHashHolder.RebuildCookie())
      {
        int index = 0;
        var weight = myOptions.InitialWeight;

        foreach (var node in myGraph.Nodes)
        {
          if (!VisitNode(node))
            continue;

          var factory = JVRPair<T>.Factory(node.Coordinate);
          
          foreach (var edge in myGraph.GetEdges(node))
          {
            if (!VisitNode(edge))
              continue;

            var key = factory.Create(edge.Coordinate);
            
            myStraitEdges.Add(key);
            myBackEdges.Add(key);

            cookie.SetItem(key, weight.Weight(++index));
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
      const double maxValue = 3;

      bool notIncludeSelfLoop = myOptions.IncludeSelfEdge;

      while (true)
      {
        T node = myHashHolder.NextNode();

        double incoming = myBackEdges.ComputeWeight(node);
        double outgoing = myStraitEdges.ComputeWeight(node);
        bool needNorm = false;

        //this is a fix for JVR method refered to JVR2
        if (notIncludeSelfLoop && myGraph.IsSelfLoop(node))
        {
          var weight = myHashHolder.GetItem(new JVRPair<T>(node, node));
          incoming -= weight;
          outgoing -= weight;
        }

        needNorm |= (incoming >= maxValue || outgoing >= maxValue);

        var sout = Math.Sqrt(outgoing);
        var sin = Math.Sqrt(incoming);
        
        double a = sout/sin;
        double b = sin/sout;

        if (IsInvalid(a) || IsInvalid(b))
        {
          a = 0;
          b = 0;
        }

        if (needNorm)
          Norm();

        var cookie = myHashHolder.UpdateCookie(myStraitEdges, myBackEdges);
        using (cookie)
        {
          myBackEdges.MultiplyWeight(cookie, node, a);
          myStraitEdges.MultiplyWeight(cookie, node, b);
        }
        
        if (CheckExitCondition(precision, incoming, outgoing, cookie.Change))
          break;
      }
    }

    private bool CheckExitCondition(double precision, double incoming, double outgoing, double change)
    {
      switch(myOptions.ExitCondition)
      {
        case JVRExitCondition.MaxNodeError:
          return Math.Abs(incoming - outgoing) <= precision;
        case JVRExitCondition.MaxRelativeNodeError:
          return Math.Abs(incoming - outgoing) <= precision * myCellVolume;
        case JVRExitCondition.SummError:
          return myHashHolder.SummaryError <= precision;
        case JVRExitCondition.ChangeError:
          return change <= precision;
        default:
          throw new Exception("Unexpected exit condition " + myOptions.ExitCondition);
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