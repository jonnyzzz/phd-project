using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl
{
  public static class ContextHelper
  {
    public static void ReplaceTypedGraphComponents(this Context ctx, IGraphStrongComponents comps)
    {
      comps.DoGeneric(new ReplaceTypedComponents(ctx));
    }

    private class ReplaceTypedComponents : IGraphStrongComponentsWith
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
    }
  }
}