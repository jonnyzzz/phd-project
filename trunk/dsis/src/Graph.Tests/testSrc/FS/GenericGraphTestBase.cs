using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.IntegerCoordinates.Impl;
using DSIS.IntegerCoordinates.Tests;
using DSIS.Utils;

namespace DSIS.Graph.Tests.FS
{
  public abstract class GenericGraphTestBase
  {
    public abstract IGraphBuilder<TCell> CreateBuilder<TCell>(ICellCoordinateSystem<TCell> system, ICellCoordinateSystemPersist<TCell> persist) where TCell : ICellCoordinate;

    public void TestGraphEdgesBuilt(IEnumerable<Pair<int, IEnumerable<int>>> edges)
    {
      CreateContext().CheckGraphNodesAndEdges(edges);
    }

    public void TestGraphDataHolder<TData>(IEnumerable<Pair<int, IEnumerable<int>>> edges, IEnumerable<Pair<int, TData>> data)
    {
      CreateContext().CheckDataHolder(edges, data);
    }

    public void TestGraphStrongComponents(IEnumerable<Pair<int, IEnumerable<int>>> edges, IEnumerable<IEnumerable<int>> comps)
    {
      CreateContext().CheckStrongComponents(edges, comps);
    }

    protected IEnumerable<T> e<T>(params T[] pars)
    {
      return pars;
    }

    protected Pair<int, IEnumerable<int>> p(int from, params int[] tos)
    {
      return Pair.Of(from, (IEnumerable<int>)tos);
    }
    
    private ITestContext CreateContext()
    {
      return new ICSTestContext(this);
    }
     
    private class ICSTestContext : TestContext<IntegerCoordinate>
    {
      private readonly IntegerCoordinateSystem myIcs = new IntegerCoordinateSystem(new MockSystemSpace(1, 0, 1, 100000));

      public ICSTestContext(GenericGraphTestBase host) : base(host)
      {
      }

      protected override ICellCoordinateSystem<IntegerCoordinate> CoordinateSystem
      {
        get { return myIcs; }
      }

      protected override ICellCoordinateSystemPersist<IntegerCoordinate> CoordinateSystemPersist
      {
        get { return myIcs; }
      }

      public override IntegerCoordinate Convert(int i)
      {
        return myIcs.Create(i);
      }

      public override int Convert(IntegerCoordinate cell)
      {
        return (int)cell.myCoordinate[0];
      }

      protected override bool IsNotNull(IntegerCoordinate cell)
      {
        return !myIcs.IsNull(cell);
      }
    }
  }
}