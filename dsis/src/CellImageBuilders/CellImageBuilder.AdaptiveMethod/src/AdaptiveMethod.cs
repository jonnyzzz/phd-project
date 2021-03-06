using System.Collections.Generic;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.AdaptiveMethod
{
  public class AdaptiveMethod<Q> : IntegerCoordinateMethodBase<Q>, ICellImageBuilder<Q>
    where Q : IIntegerCoordinate
  {
    private static readonly PointGraphInitialBuilder BUILDER = new PointGraphInitialBuilder();

    private IGraphBuilderProcessor myGraphBuilder;
    private double[] myD;
    private IFunction<double> myFunction;
    private AdaptiveMethodSettings mySettings;
    private double[] myEps;
    private IPointProcessor<Q> myPointProcessor;
    private IRadiusProcessor<Q> myRadiusProcessor;

    private readonly List<Q> myPoints = new List<Q>();
    private readonly Queue<PointGraphEdge> myQueue = new Queue<PointGraphEdge>();


    public override void Bind(CellImageBuilderContext<Q> context)
    {
      base.Bind(context);
      myGraphBuilder = BUILDER.BuildGraph(myDim).Init(mySystem);
      myD = new double[myDim];
      myFunction = context.Function.GetFunction<double>(mySystem.CellSize);
      mySettings = (AdaptiveMethodSettings) context.Settings;
      myEps = new double[myDim];
      var eps2 = new double[myDim];
      for(int i =0; i<myDim; i++)
      {
        double d = mySystem.CellSize[i]*mySettings.Eps;
        myEps[i] = d;
        eps2[i] = mySettings.OveplapFactor;
      }
      myPointProcessor = mySystem.ProcessorFactory.CreateOverlapedPointProcessor(eps2);
      myRadiusProcessor = mySystem.ProcessorFactory.CreateRadiusProcessor();
    }

    public void BuildImage(Q coord)
    {
      int count = 0;

      mySystem.TopLeftPoint(coord, myD);
      var graph = new PointGraph(myFunction, myEps);
      IEnumerable<PointGraphEdge> edges = myGraphBuilder.BuildGraph(graph, myD);
      myQueue.Clear();
      myPoints.Clear();
      foreach (PointGraphEdge edge in edges)
      {
        myQueue.Enqueue(edge);
        count++;
      }
      
      while(myQueue.Count > 0 && count < mySettings.EdgesPerCell)
      {
        count++;
        PointGraphEdge edge = myQueue.Dequeue();
        if (!graph.CheckDistance(edge.Node1, edge.Node2))
        {
          var sub = graph.Subdivide(edge.Node1, edge.Node2);
          foreach (var e in sub.Second)
          {
            myQueue.Enqueue(e);
          }
        } else
        {
          double[] doubles = graph.Evaluate(edge.Node1);
          myPoints.AddRange(myPointProcessor.AddPoint(doubles));
          
          doubles = graph.Evaluate(edge.Node2);
          myPoints.AddRange(myPointProcessor.AddPoint(doubles));
        }
      }

      while(myQueue.Count > 0)
      {
        PointGraphEdge edge = myQueue.Dequeue();
        graph.ComputeDistance(edge.Node1, edge.Node2, myD);
        myPoints.AddRange(myRadiusProcessor.ConnectCellToRadius(graph.Evaluate(edge.Node1), myD));
        myPoints.AddRange(myRadiusProcessor.ConnectCellToRadius(graph.Evaluate(edge.Node2), myD));
      }

      myBuilder.ConnectToMany(coord, myPoints);
      myPoints.Clear();
    }

    public ICellImageBuilder<Q> Clone()
    {
      return new AdaptiveMethod<Q>();
    }
  }
}
