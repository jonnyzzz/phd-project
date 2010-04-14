using System;
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

    private class ReplaceTypedComponents : IReadonlyGraphStrongComponentsWith, IIntegerCoordinateSystemWith
    {
      private readonly Context myContext;

      public ReplaceTypedComponents(Context context)
      {
        myContext = context;
      }

      public void With<TCell, TNode>(IReadonlyGraphStrongComponents<TCell, TNode> components) where TCell : ICellCoordinate where TNode : class, INode<TCell>
      {
        myContext.Remove(Keys.GetGraphComponents<TCell>());
        myContext.Remove(Keys.GraphComponents);

        myContext.Set(Keys.GetGraphComponents<TCell>(), components.Upcast);
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