using System;
using DSIS.Core.Coordinates;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.Utils;
using System.Linq;

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
    private readonly int myNodesCount;

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
      myNodesCount = components.Components.Sum(x => x.NodesCount);

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

    protected int QueueSize
    {
      get { return myHashHolder.PriorityQueueNodes; }
    }

    protected void Norm()
    {
      myHashHolder.Normalize();
    }

    public void Iterate(double precision)
    {
      const double maxValue = 3;
      const int maxSteps = 20;

      bool notIncludeSelfLoop = myOptions.IncludeSelfEdge;
      int stepCount = 0;

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

        needNorm |= stepCount > maxSteps;

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
        {
          Norm();
          stepCount = 0;
        }

        var cookie = myHashHolder.UpdateCookie(myStraitEdges, myBackEdges);
        var edgesChange = 0.0;
        using (cookie)
        {
          edgesChange += myBackEdges.MultiplyWeight(cookie, node, a);
          edgesChange += myStraitEdges.MultiplyWeight(cookie, node, b);
        }

        double qValue = Math.Abs(incoming - outgoing);
        if (CheckExitCondition(myOptions.ExitCondition, precision, myHashHolder.SummaryError, qValue, cookie.Change,
                               edgesChange))
          break;
      }
    }

    protected virtual bool CheckExitCondition(JVRExitCondition condition,
                                              double precision,
                                              double totalError,
                                              double qValue,
                                              double nodesChange,
                                              double edgesChange)
    {
      //TODO: Replace with delegate
      switch (condition)
      {
        case JVRExitCondition.MaxNodeError:
          return qValue <= precision;

        case JVRExitCondition.MaxRelativeNodeError:
          return qValue <= precision * myCellVolume;

        case JVRExitCondition.SummError:
          return totalError <= precision;

        case JVRExitCondition.RelativeSummError:
          return totalError <= precision * myNodesCount;

        case JVRExitCondition.NodeChangeError:
          return nodesChange <= precision;

        case JVRExitCondition.NodeRelativeChangeError:
          return nodesChange <= precision * myCellVolume;

        case JVRExitCondition.EdgesChangeError:
          return edgesChange <= precision;

        case JVRExitCondition.EdgesRelativeChangeError:
          return edgesChange <= precision * myCellVolume;

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