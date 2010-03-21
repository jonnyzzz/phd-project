using System;
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
      var cellImageBuilder = CreateBuilder(mySettings); 
      
      var p = new Proxy();
      myGraph.DoGeneric(p);
     
      var builder = p.Builder;
      cellImageBuilder.Bind(new CellImageBuilderContext<Q>(
                              myFunction, 
                              mySettings, 
                              myGraph.CoordinateSystem, 
                              builder
                              ));

      foreach (INode<Q> node in myGraph.Nodes)
      {
        cellImageBuilder.BuildImage(node.Coordinate);
      }

      double norm = builder.Norm();

      return new GraphMeasure<Q, NodePair<Q>>(
        "Intersection", 
        builder.Vector.Dictionary, 
        EqualityComparerFactory<Q>.GetReferenceComparer(), 
        norm, 
        myGraph.CoordinateSystem
        );
    }

    private class Proxy : IReadonlyGraphWith<Q>
    {
      public ICellConnectionBuilderEx Builder { get; private set; }
      public void With<TNode>(IReadonlyGraph<Q, TNode> graph) where TNode : class, INode<Q>
      {
        Builder = new CellConnectionBuilderImpl<TNode>(graph);
      }
    } 

    private interface ICellConnectionBuilderEx : ICellConnectionBuilder<Q>
    {
      Vector<NodePair<Q>> Vector { get; }

      double Norm();
    }

    private class CellConnectionBuilderImpl<TNode> : ICellConnectionBuilderEx where TNode : class, INode<Q>
    {
      private readonly Vector<NodePair<Q>> myVector = new Vector<NodePair<Q>>();
      private readonly Vector<Q> myNodePoints = new Vector<Q>();
      private readonly IReadonlyGraph<Q,TNode> myGraph;

      public CellConnectionBuilderImpl(IReadonlyGraph<Q,TNode> graph)
      {       
        myGraph = graph;
      }

      void ICellConnectionBuilder<Q>.ConnectToOne(Q cell, Q v)
      {
        if (!myGraph.Contains(v)) return;

        myVector.Add(new NodePair<Q>(cell, v), 1);
        myNodePoints.Add(cell, 1);
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

      public double Norm()
      {
        double sum = 0;
        foreach (var node in myGraph.NodesInternal)
        {
          Q cell = node.Coordinate;
          int cellHash = NodePair<Q>.HashValue(cell);
          double count = myNodePoints[cell];
          foreach (INode<Q> edge in myGraph.GetEdgesInternal(node))
          {
            sum += myVector.Div(new NodePair<Q>(cell, cellHash, edge.Coordinate), count);
          }
        }                
        return sum;
      }     
    }
  }
}