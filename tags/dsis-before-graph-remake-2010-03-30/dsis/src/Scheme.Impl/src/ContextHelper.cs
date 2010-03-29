using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl
{
  public static class ContextHelper
  {
    public static void ReplaceTypedGraphComponents(this Context ctx, IGraphStrongComponents comps)
    {
      comps.DoGeneric(new ReplaceTypedComponents(ctx));
    }

    private class ReplaceTypedComponents : IGraphStrongComponentsWith, IIntegerCoordinateSystemWith
    {
      private readonly Context myContext;

      public ReplaceTypedComponents(Context context)
      {
        myContext = context;
      }

      public void With<Q>(IGraphStrongComponents<Q> components) where Q : ICellCoordinate
      {
        myContext.Remove(Keys.GetGraphComponents<Q>());
        myContext.Remove(Keys.GraphComponents);

        myContext.Set(Keys.GetGraphComponents<Q>(), components);
      }

      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        myContext.Remove(Keys.IntegerCoordinateSystemInfo);
        myContext.Set(Keys.IntegerCoordinateSystemInfo, system);
      }
    }

    public static void ReplaceTypedIntegerCoordinateSystem(this Context ctx, IIntegerCoordinateSystem system)
    {
      system.DoGeneric(new ReplaceTypedComponents(ctx));
    }
  }
}