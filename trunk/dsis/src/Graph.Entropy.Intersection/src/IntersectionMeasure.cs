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

      double norm = builder.Norm(myGraph);

      return new GraphMeasure<Q, NodePair<Q>>(
        "Intersection", 
        builder.Vector.Dictionary, 
        EqualityComparerFactory<Q>.GetReferenceComparer(), 
        norm, 
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

      public double Norm(IGraph<Q> graph)
      {
        
        Vector<Q> mi = new Vector<Q>();
        foreach (INode<Q> node in graph.Nodes)
        {
          Q cell = node.Coordinate;
          int cellHash = NodePair<Q>.HashValue(cell);
          double count = myNodePoints[cell];
          double t = 0;
          foreach (INode<Q> edge in graph.GetEdges(node))
          {
            t+= (myVector[new NodePair<Q>(cell, cellHash, edge.Coordinate)] /= count);                        
          }

          mi.Add(cell, t);
        }

        double sum = 0;
        foreach (INode<Q> node in graph.Nodes)
        {
          Q cell = node.Coordinate;
          int cellHash = NodePair<Q>.HashValue(cell);
          double dv = mi[cell];

          foreach (INode<Q> edge in graph.GetEdges(node))
          {
            sum += (myVector[new NodePair<Q>(cell, cellHash, edge.Coordinate)] /= dv);
          }
        }

        return sum;
      }     
    }
  }
}