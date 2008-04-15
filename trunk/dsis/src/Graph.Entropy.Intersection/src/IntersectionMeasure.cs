using System.Collections.Generic;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Intersection
{
  public abstract class IntersectionMeasure<Q> 
    where Q : ICellCoordinate
  {
    private readonly IGraph<Q> myGraph;
    private readonly ISystemInfo myFunction;
    private readonly ICellImageBuilderSettings mySettings;
    
    public IntersectionMeasure(ISystemInfo function, IGraph<Q> graph, ICellImageBuilderSettings settings)
    {
      myGraph = graph;
      myFunction = function;
      mySettings = settings;
    }

    protected abstract ICellImageBuilder<Q> CreateBuilder(ICellImageBuilderSettings settings);

    public IGraphMeasure<Q> Start()    
    {
      ICellImageBuilder<Q> cellImageBuilder = CreateBuilder(mySettings);            
      CellConnectionBuilderImpl builder = new CellConnectionBuilderImpl(myGraph);
      cellImageBuilder.Bind(new CellImageBuilderContext<Q>(
                              myFunction, 
                              mySettings, myGraph.CoordinateSystem, builder
                              ));

      foreach (INode<Q> node in myGraph.Nodes)
      {
        cellImageBuilder.BuildImage(node.Coordinate);
      }

      builder.Norm(myGraph);

      return new GraphMeasure<Q, NodePair<Q>>(
        "Intersection", 
        builder.Vector.Dictionary, 
        EqualityComparerFactory<Q>.GetReferenceComparer(), 
        1.0, 
        myGraph.CoordinateSystem
        );
    }

    protected class CellConnectionBuilderImpl : ICellConnectionBuilder<Q>
    {
      private readonly Vector<NodePair<Q>> myVector = new Vector<NodePair<Q>>();
      private readonly Vector<Q> myNodePoints = new Vector<Q>();
      private readonly IGraph<Q> myGraph;

      public CellConnectionBuilderImpl(IGraph<Q> graph)
      {       
        myGraph = graph;
      }

      void ICellConnectionBuilder<Q>.ConnectToOne(Q cell, Q v)
      {
        if (myGraph.Contains(v))
        {
          myVector.Add(new NodePair<Q>(cell, v), 1);
          myNodePoints.Add(cell, 1);
        }
      }

      void ICellConnectionBuilder<Q>.ConnectToMany(Q cell, IEnumerable<Q> v)
      {
        int cellHash = NodePair<Q>.HashValue(cell);
        long cnt = 0;
        foreach (Q q in v)
        {
          if (myGraph.Contains(q))
          {
            myVector.Add(new NodePair<Q>(cell, cellHash, q), 1);
            cnt++;
          }
        }
        myNodePoints.Add(cell, cnt);
      }

      public Vector<NodePair<Q>> Vector
      {
        get { return myVector; }
      }

      public void Norm(IGraph<Q> graph)
      {
        foreach (INode<Q> node in graph.Nodes)
        {
          Q cell = node.Coordinate;
          int cellHash = NodePair<Q>.HashValue(cell);
          foreach (INode<Q> edge in graph.GetEdges(node))
          {
            myVector[new NodePair<Q>(cell, cellHash, edge.Coordinate)] /= myNodePoints[cell]*graph.NodesCount;            
          }          
        }
      }
    }
  }
}