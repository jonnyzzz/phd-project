using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;

namespace DSIS.UI.ComputationDialogs.Constraints
{
  public abstract class IntegerCoordinateComponentConstraint : ISIComputationConstraint
  {
    protected abstract bool CanContinue<T, Q>(T system, Context ctx)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;

    private class With : IIntegerCoordinateSystemWith
    {
      private readonly IntegerCoordinateComponentConstraint myHost;
      private readonly Context myContext;

      public With(IntegerCoordinateComponentConstraint host, Context context)
      {
        myHost = host;
        myContext = context;
      }

      public bool Result { get; private set; }

      public void Do<T, Q>(T system) 
        where T : IIntegerCoordinateSystem<Q> 
        where Q : IIntegerCoordinate
      {
        Result = myHost.CanContinue<T, Q>(system, myContext);
      }
    }

    public bool CanContinue(Context ctx)
    {
      if (!ctx.ContainsKey(Keys.IntegerCoordinateSystemInfo))
        return false;
      var ics = Keys.IntegerCoordinateSystemInfo.Get(ctx);
      var w = new With(this, ctx);
      ics.DoGeneric(w);
      return w.Result;
    }
  }
}