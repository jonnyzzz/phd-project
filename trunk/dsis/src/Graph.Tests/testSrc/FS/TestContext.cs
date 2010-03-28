using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Tests.FS
{
  public abstract class TestContext<TCell> : ITestContext
    where TCell : ICellCoordinate
  {
    private readonly GenericGraphTestBase myHost;
    protected abstract TCell Convert(int i);
    public abstract int Convert(TCell cell);
    protected abstract bool IsNotNull(TCell cell);
    protected abstract ICellCoordinateSystem<TCell> CoordinateSystem { get; }
    protected abstract ICellCoordinateSystemPersist<TCell> CoordinateSystemPersist { get; }

    protected TestContext(GenericGraphTestBase host)
    {
      myHost = host;
    }

    public void CheckGraphNodesAndEdges(IEnumerable<Pair<int, IEnumerable<int>>> edges)
    {
      var readonlyGraph = BuildGraph(edges);
      DumpGraph(readonlyGraph);
      CheckBuiltGraph(edges, readonlyGraph);
    }

    private void DumpGraph(IReadonlyGraph<TCell> graph)
    {
      WithGraph(graph).DumpGraph();      
    }

    private IReadonlyGraph<TCell> BuildGraph(IEnumerable<Pair<int, IEnumerable<int>>> edges)
    {
      var builder = myHost.CreateBuilder(CoordinateSystem, CoordinateSystemPersist);
      using (var writer = builder.GetWriter())
      {
        foreach (var edge in ConvertEdges(edges).ToArray())
        {
          var cells = edge.Second.ToArray();
          Console.Out.WriteLine("adding = {0} --> {1}", Convert(edge.First), cells.JoinString(x=>Convert(x).ToString(), ", "));

          writer.AddEdges(edge.First, cells);
        }
      }

      return builder.BuildFinished();
    }

    private IEnumerable<Pair<TCell, IEnumerable<TCell>>> ConvertEdges(IEnumerable<Pair<int, IEnumerable<int>>> edges)
    {
      return edges.Select(
        x => Pair.Of(Convert(x.First), x.Second.Select(Convert).Where(IsNotNull)))
        .Where(x => IsNotNull(x.First));
    }

    private void CheckBuiltGraph(IEnumerable<Pair<int, IEnumerable<int>>> edges, IReadonlyGraph<TCell> graph)
    {
      WithGraph(graph).CheckBuiltGraphEdges(edges);
    }

    private ITestContextWithGraph<TCell> WithGraph(IReadonlyGraph<TCell> graph)
    {
      var with = new TestContextWithGraphFactory<TCell>(this);
      graph.DoGeneric(with);
      return with.Context;
    }
  }
}