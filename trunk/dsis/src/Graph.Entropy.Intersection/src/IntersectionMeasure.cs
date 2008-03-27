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
      Vector<NodePair<Q>> myVector = new Vector<NodePair<Q>>();

      ICellImageBuilder<Q> cellImageBuilder = CreateBuilder(mySettings);            
      CellConnectionBuilderImpl builder = new CellConnectionBuilderImpl(myVector, myGraph);
      cellImageBuilder.Bind(new CellImageBuilderContext<Q>(
                              myFunction, 
                              mySettings, myGraph.CoordinateSystem, builder
                              ));

      foreach (INode<Q> node in myGraph.Nodes)
      {
        cellImageBuilder.BuildImage(node.Coordinate);
      }

      double norm = 0;
      foreach (INode<Q> node in myGraph.Nodes)
      {
        double cnt = 0;
        Dictionary<NodePair<Q>, double> values = new Dictionary<NodePair<Q>, double>();
        int nodeHash = NodePair<Q>.HashValue(node.Coordinate);
        foreach (INode<Q> edge in myGraph.GetEdges(node))
        {
          NodePair<Q> data = new NodePair<Q>(node.Coordinate, nodeHash, edge.Coordinate);
          double times = myVector[data];
          values.Add(data, times);
          cnt += times;
        }

        foreach (KeyValuePair<NodePair<Q>, double> pair in values)
        {
          double n = pair.Value/cnt;
          norm += n;
          myVector[pair.Key] = n;
        }
      }

      return new GraphMeasure<Q, NodePair<Q>>("Intersection", myVector.Dictionary, EqualityComparerFactory<Q>.GetReferenceComparer(), norm, myGraph.CoordinateSystem);
    }

    private class CellConnectionBuilderImpl : ICellConnectionBuilder<Q>
    {
      private readonly Vector<NodePair<Q>> myVector;
      private readonly IGraph<Q> myGraph;

      public CellConnectionBuilderImpl(Vector<NodePair<Q>> vector, IGraph<Q> graph)
      {
        myVector = vector;
        myGraph = graph;
      }

      public void ConnectToOne(Q cell, Q v)
      {
        if (myGraph.Contains(v))
        {
          myVector.Add(new NodePair<Q>(cell, v), 1);
        }
      }

      public void ConnectToMany(Q cell, IEnumerable<Q> v)
      {
        int cellHash = NodePair<Q>.HashValue(cell);
        foreach (Q q in v)
        {
          if (myGraph.Contains(q))
          {
            myVector.Add(new NodePair<Q>(cell, cellHash, q), 1);
          }
        }
      }      
    }
  }
}