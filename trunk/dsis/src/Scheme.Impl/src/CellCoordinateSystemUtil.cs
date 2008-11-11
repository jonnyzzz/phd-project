using DSIS.Core.Coordinates;
using DSIS.Scheme.Ctx;

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

    private class ActionCount : ICellCoordinateWith
    {
      private readonly IReadOnlyContext myContext;
      public long Count { get; private set; }

      public ActionCount(IReadOnlyContext context)
      {
        myContext = context;
      }

      
      public void With<Q>(ICellCoordinateSystem<Q> system) where Q : ICellCoordinate
      {
        var key = Keys.CellsEnumerationKey<Q>();
        if (myContext.ContainsKey(key))
          Count = key.Get(myContext).Count;

        Count = 0;
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
  }
}