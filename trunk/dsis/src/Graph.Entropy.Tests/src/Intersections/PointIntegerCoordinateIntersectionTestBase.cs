using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Function.Mock;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.Graph.Entropy.Intersection;
using DSIS.Graph.Tarjan;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Impl;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Tests.Intersections
{
  public abstract class PointIntegerCoordinateIntersectionTestBase : EntropyBlackboxTest
  {
    private bool myShouldWork;
    private ConnectionType myType;

    protected override Pair<IGraphMeasure<IntegerCoordinate>, IEdgeInfo> CreateEvaluator(
      string script,
      TarjanGraph<IntegerCoordinate> gr,
      IGraphStrongComponents<IntegerCoordinate> comps)
    {
      var ms = new Measure(myType, gr);
      GraphMeasure<IntegerCoordinate, NodePair<IntegerCoordinate>> start = ms.Start();

      return Pair.Of<IGraphMeasure<IntegerCoordinate>, IEdgeInfo>(
        start, new GraphMeasureEdgeInfo<NodePair<IntegerCoordinate>>(
          start, (from, to) => new NodePair<IntegerCoordinate>(from, to))
        );
    }

    protected enum ConnectionType
    {
      One,
      Many
    }

    protected void DoTest(ConnectionType type, double entropy, params Node[] nodes)
    {
      try
      {
        myShouldWork = true;
        myType = type;

        DoTest(string.Empty, entropy, nodes);
      }
      finally
      {
        myShouldWork = false;
      }
    }


    protected override void DoTest(string script, double entropy, params Node[] nodes)
    {
      if (!myShouldWork)
        throw new Exception("This method cann't be called here. Use DoTest(ComputeOneFucntion<double>, ...) method");

      base.DoTest(script, entropy, nodes);
    }

    private class CellImageBuilderSettings : ICellImageBuilderIntegerCoordinatesSettings
    {
      private readonly DCreate myCreate;

      public CellImageBuilderSettings(DCreate create)
      {
        myCreate = create;
      }

      public delegate ICellImageBuilder<IntegerCoordinate> DCreate();

      public ICellImageBuilder<TCell> Create<TCell>() where TCell : IIntegerCoordinate
      {
        return (ICellImageBuilder<TCell>)myCreate();
      }

      public string PresentableName
      {
        get { return "Fake Buildser"; }
      }
    }

    private class GraphCellConnectionAddOneBuilder<TNode> : GraphCellImageBuilder<TNode> where TNode : class, INode<IntegerCoordinate>
    {
      public GraphCellConnectionAddOneBuilder(IReadonlyGraph<IntegerCoordinate, TNode> graph) : base(graph)
      {
      }

      protected override void AddConnections(IntegerCoordinate from, ICellConnectionBuilder<IntegerCoordinate> bld,
                                             IEnumerable<IntegerCoordinate> tos)
      {
        foreach (IntegerCoordinate to in tos)
        {
          bld.ConnectToOne(from, to);
        }
      }

      public override ICellImageBuilder<IntegerCoordinate> Clone()
      {
        return new GraphCellConnectionAddOneBuilder<TNode>(myGraph);
      }
    }

    private class GraphCellConnectionAddManyBuilder<TNode> : GraphCellImageBuilder<TNode> where TNode : class, INode<IntegerCoordinate>
    {
      public GraphCellConnectionAddManyBuilder(IReadonlyGraph<IntegerCoordinate, TNode> graph) : base(graph)
      {
      }

      protected override void AddConnections(IntegerCoordinate from, ICellConnectionBuilder<IntegerCoordinate> bld,
                                             IEnumerable<IntegerCoordinate> tos)
      {
        bld.ConnectToMany(from, tos);
      }

      public override ICellImageBuilder<IntegerCoordinate> Clone()
      {
        return new GraphCellConnectionAddManyBuilder<TNode>(myGraph);
      }
    }

    private abstract class GraphCellImageBuilder<TNode> : ICellImageBuilder<IntegerCoordinate> where TNode : class, INode<IntegerCoordinate>
    {
      protected readonly IReadonlyGraph<IntegerCoordinate, TNode> myGraph;
      private CellImageBuilderContext<IntegerCoordinate> myContext;

      protected GraphCellImageBuilder(IReadonlyGraph<IntegerCoordinate, TNode> graph)
      {
        myGraph = graph;
      }

      public void Bind(CellImageBuilderContext<IntegerCoordinate> cellImageBuilderContext)
      {
        myContext = cellImageBuilderContext;
      }

      protected abstract void AddConnections(IntegerCoordinate from, ICellConnectionBuilder<IntegerCoordinate> bld,
                                             IEnumerable<IntegerCoordinate> tos);

      public void BuildImage(IntegerCoordinate coord)
      {
        var nodes = myGraph.Find(coord);
        var lst = myGraph.GetEdgesInternal(nodes).Select(edge => edge.Coordinate).ToList();
        AddConnections(coord, myContext.ConnectionBuilder, lst);
      }

      public abstract ICellImageBuilder<IntegerCoordinate> Clone();

      public string PresentableName
      {
        get { return "Graph based builder"; }
      }
    }

    

    private class Measure : IntegerCoordinateIntersectionMeasure<IntegerCoordinate>
    {
      public Measure(ConnectionType type, IGraph<IntegerCoordinate> graph) :
        base(new MockSystemInfo<double>(
               Proxy,
               graph.CoordinateSystem.SystemSpace),
             graph,
             new CellImageBuilderSettings(
               delegate
                 {
                   var cv = new CreateBuilderForGraph(type);
                   graph.DoGeneric(cv);
                   return cv.Builder;
                 }))
      {
      }

      private class CreateBuilderForGraph : IReadonlyGraphWith<IntegerCoordinate>
      {
        public ICellImageBuilder<IntegerCoordinate> Builder { get; private set; }
        private readonly ConnectionType type;

        public CreateBuilderForGraph(ConnectionType type)
        {
          this.type = type;
        }

        public void With<TNode>(IReadonlyGraph<IntegerCoordinate, TNode> graph) where TNode : class, INode<IntegerCoordinate>
        {
          switch (type)
          {
            case ConnectionType.Many:
              Builder = new GraphCellConnectionAddManyBuilder<TNode>(graph);
              return;
            case ConnectionType.One:
              Builder = new GraphCellConnectionAddOneBuilder<TNode>(graph);
              return;
            default:
              throw new NotImplementedException();
          }
        }
      }

      private static void Proxy<T>(T[] ins, T[] outs)
      {
      }

      public new GraphMeasure<IntegerCoordinate, NodePair<IntegerCoordinate>> Start()
      {
        return (GraphMeasure<IntegerCoordinate, NodePair<IntegerCoordinate>>) base.Start();
      }
    }
  }
}