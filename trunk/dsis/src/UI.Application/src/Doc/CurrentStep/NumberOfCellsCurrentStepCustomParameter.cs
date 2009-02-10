using System;
using DSIS.Core.Coordinates;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Doc.CurrentStep
{
  [DocumentComponent]
  public class NumberOfCellsCurrentStepCustomParameter : IntegerCoordinateStepCustomParameterBase
  {
    public override string Name
    {
      get { return "Number of Cells(Edges)"; }
    }

    public override int Order
    {
      get { return (int)StepOrders.NumberOfCells; }
    }

    protected override bool IsAvailable<T, Q>(T cs, Context ctx)
    {
      var pair = Count<Q>(ctx);
      return pair.First != null || pair.Second != null;
    }

    private static Pair<int?, int?> Count<Q>(Context myContext)
      where Q : ICellCoordinate
    {
      var key = Keys.Graph<Q>();
      if (myContext.ContainsKey(key))
      {
        var graph = key.Get(myContext);
        return Pair.Of<int?, int?>(graph.NodesCount, graph.EdgesCount);
      }

      var key2 = Keys.GraphMeasure<Q>();
      if (myContext.ContainsKey(key2))
      {
        var measure = key2.Get(myContext);
        return Pair.Of<int?, int?>(measure.NodesCount, measure.EdgesCount);
      }

      var key3 = Keys.CellsEnumerationKey<Q>();
      if (myContext.ContainsKey(key3))
      {
        return Pair.Of<int?, int?>(key3.Get(myContext).Count, null);
      }

      var key4 = Keys.GraphComponents<Q>();
      if (myContext.ContainsKey(key4))
      {
        var components = key4.Get(myContext);
        return Pair.Of<int?, int?>(components.Components.FoldLeft(0, (x, v) => v + x.NodesCount), null);
      }

      return Pair.Of<int?, int?>(null, null);
    }

    protected override string GetValue<T, Q>(T cs, Context ctx)
    {
      var q = Count<Q>(ctx);
      String result = string.Empty;

      if (q.First != null)
      {
        result += q.First.Value.ToString("N0");
      }

      if (q.Second != null)
      {
        result += " (" + q.Second.Value.ToString("N0") + ")";
      }
      return result;
    }
  }
}