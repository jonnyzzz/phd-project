using DSIS.Core.Coordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl
{
  public static class CellCoordinateSystemUtil
  {
    public static long CellEnumeratorCount(this IReadOnlyContext context)
    {
      var cs = Keys.IntegerCoordinateSystemInfo.Get(context);
      var action = new Action(context);
      cs.DoGeneric(action);
      return action.Count;
    }

    private class Action : ICellCoordinateWith
    {
      private readonly IReadOnlyContext myContext;

      public Action(IReadOnlyContext context)
      {
        myContext = context;
      }

      public long Count { get; set; }
      public void With<Q>(ICellCoordinateSystem<Q> system) where Q : ICellCoordinate
      {
        Count = Keys.CellsEnumerationKey<Q>().Get(myContext).Count;
      }
    }
  }
}