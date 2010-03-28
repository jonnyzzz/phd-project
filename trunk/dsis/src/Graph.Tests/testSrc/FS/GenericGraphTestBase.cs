using System.Collections;
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

    protected IEnumerable<Pair<int, IEnumerable<int>>> e(params Pair<int, IEnumerable<int>>[] pars)
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

      protected override IntegerCoordinate Convert(int i)
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