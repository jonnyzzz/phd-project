using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Tests.FS
{
  public interface ITestContext
  {
    void CheckGraphNodesAndEdges(IEnumerable<Pair<int, IEnumerable<int>>> edges);
  }

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
      CheckBuiltGraph(edges, BuildGraph(edges));
    }


    public IReadonlyGraph<TCell> BuildGraph(IEnumerable<Pair<int, IEnumerable<int>>> edges)
    {
      var builder = myHost.CreateBuilder<TCell>(CoordinateSystem, CoordinateSystemPersist);
      using (var writer = builder.GetWriter())
      {
        foreach (var edge in ConvertEdges(edges))
        {
          writer.AddEdges(edge.First, edge.Second);
        }
      }

      return builder.BuildFinished();
    }

    public IEnumerable<Pair<TCell, IEnumerable<TCell>>> ConvertEdges(IEnumerable<Pair<int, IEnumerable<int>>> edges)
    {
      return edges.Select(x => Pair.Of(Convert(x.First), x.Second.Select(Convert).Where(IsNotNull)))
        .Where(x => IsNotNull(x.First));
    }

    public void CheckBuiltGraph(IEnumerable<Pair<int, IEnumerable<int>>> edges, IReadonlyGraph<TCell> graph)
    {
      WithGraph(graph).CheckBuiltGraphEdges(edges);
    }

    protected ITestContextWithGraph<TCell> WithGraph(IReadonlyGraph<TCell> graph)
    {
      var with = new TestContextWithGraphFactory<TCell>(this);
      graph.DoGeneric(with);
      return with.Context;
    }
  }
}