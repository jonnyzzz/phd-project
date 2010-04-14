using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Utils;
using DSIS.Graph.Abstract.Algorithms;

namespace DSIS.Graph.Tests.FS
{
  public abstract class TestContext<TCell> : ITestContext
    where TCell : ICellCoordinate
  {
    private readonly GenericGraphTestBase myHost;
    public abstract TCell Convert(int i);
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

    public void CheckDataHolder<TData>(IEnumerable<Pair<int, IEnumerable<int>>> edges, IEnumerable<Pair<int, TData>> values)
    {
      var readonlyGraph = BuildGraph(edges);
      DumpGraph(readonlyGraph);
      CheckDataHolder(readonlyGraph, values);
    }

    public void CheckStrongComponents(IEnumerable<Pair<int, IEnumerable<int>>> edges, IEnumerable<IEnumerable<int>> comps)
    {
      var hashComps = new HashSet<int[]>(ArrayEqualityComparer<int>.INSTANCE);
      comps.ForEach(x=>hashComps.Add(x.ToArray()));

      var readonlyGraph = BuildGraph(edges);
      DumpGraph(readonlyGraph);

      var c = readonlyGraph.ComputeStrongComponents(NullProgressInfo.INSTANCE);
      
    }

    private 

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

    private void CheckDataHolder<TData>(IReadonlyGraph<TCell> graph, IEnumerable<Pair<int, TData>> data)
    {
      WithGraph(graph).CheckDataHolder<TData>(data);
    }

    private ITestContextWithGraph<TCell> WithGraph(IReadonlyGraph<TCell> graph)
    {
      var with = new TestContextWithGraphFactory<TCell>(this);
      graph.DoGeneric(with);
      return with.Context;
    }
  }
}