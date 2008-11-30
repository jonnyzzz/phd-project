using DSIS.Core.Coordinates;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl
{
  public static class CellCoordinateSystemUtil
  {
    public static long CellEnumeratorCount(this IReadOnlyContext context)
    {
      var cs = Keys.IntegerCoordinateSystemInfo.Get(context);
      var action = new ActionCount(context);
      cs.DoGeneric(action);
      return action.Count;
    }

    public static bool ContainsCellCollection(this IReadOnlyContext context)
    {
      if (!context.ContainsKey(Keys.IntegerCoordinateSystemInfo))
        return false;

      var cs = Keys.IntegerCoordinateSystemInfo.Get(context);
      var action = new ActionContains(context);
      cs.DoGeneric(action);
      return action.Contains;
    }

    public static bool ContainsGraph(this IReadOnlyContext context)
    {
      if (!context.ContainsKey(Keys.IntegerCoordinateSystemInfo))
        return false;

      var cs = Keys.IntegerCoordinateSystemInfo.Get(context);
      var action = new GraphContains(context);
      cs.DoGeneric(action);
      return action.Contains;
    }

    public static bool ContainsGraphMeasure(this IReadOnlyContext context)
    {
      if (!context.ContainsKey(Keys.IntegerCoordinateSystemInfo))
        return false;

      var cs = Keys.IntegerCoordinateSystemInfo.Get(context);
      var action = new GraphMeasureContains(context);
      cs.DoGeneric(action);
      return action.Contains;
    }

    private class ActionCount : ICellCoordinateWith
    {
      private readonly IReadOnlyContext myContext;
      public long Count { get; private set; }

      public ActionCount(IReadOnlyContext context)
      {
        myContext = context;
      }

      private long GetCount<Q>()
        where Q : ICellCoordinate
      {
        var key = Keys.CellsEnumerationKey<Q>();
        if (myContext.ContainsKey(key))
        {
          return key.Get(myContext).Count;
        }
        var key2 = Keys.GraphComponents<Q>();
        if (myContext.ContainsKey(key2))
        {
          var components = key2.Get(myContext);
          return components.Components.FoldLeft(0, (x, v) => v + x.NodesCount);
        }
        return 0;
      }
      
      public void With<Q>(ICellCoordinateSystem<Q> system) where Q : ICellCoordinate
      {
        Count = GetCount<Q>();
      }
    }
    private class ActionContains: ICellCoordinateWith
    {
      private readonly IReadOnlyContext myContext;
      public bool Contains { get; private set; }

      public ActionContains(IReadOnlyContext context)
      {
        myContext = context;
      }
      
      public void With<Q>(ICellCoordinateSystem<Q> system) where Q : ICellCoordinate
      {
        Contains = myContext.ContainsKey(Keys.CellsEnumerationKey<Q>());
      }
    }

    private class GraphContains: ICellCoordinateWith
    {
      private readonly IReadOnlyContext myContext;
      public bool Contains { get; private set; }

      public GraphContains(IReadOnlyContext context)
      {
        myContext = context;
      }
      
      public void With<Q>(ICellCoordinateSystem<Q> system) where Q : ICellCoordinate
      {
        Contains = myContext.ContainsKey(Keys.Graph<Q>());
      }
    }
    private class GraphMeasureContains: ICellCoordinateWith
    {
      private readonly IReadOnlyContext myContext;
      public bool Contains { get; private set; }

      public GraphMeasureContains(IReadOnlyContext context)
      {
        myContext = context;
      }
      
      public void With<Q>(ICellCoordinateSystem<Q> system) where Q : ICellCoordinate
      {
        Contains = myContext.ContainsKey(Keys.GraphMeasure<Q>());
      }
    }
  }
}