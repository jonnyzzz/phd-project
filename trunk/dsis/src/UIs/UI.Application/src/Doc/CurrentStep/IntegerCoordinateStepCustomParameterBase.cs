using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;

namespace DSIS.UI.Application.Doc.CurrentStep
{
  public abstract class IntegerCoordinateStepCustomParameterBase : ICurrentStepCustomParameter
  {
    public abstract string Name { get; }
    public abstract int Order { get; }

    public bool IsAvailable(Context ctx)
    {
      if (!ctx.ContainsKey(Keys.IntegerCoordinateSystemInfo))
        return false;

      var ics = Keys.IntegerCoordinateSystemInfo.Get(ctx);
      var with = new WithAvailable(this, ctx);
      ics.DoGeneric(with);
      return with.Result;
    }

    public string GetValue(Context ctx)
    {
      if (!ctx.ContainsKey(Keys.IntegerCoordinateSystemInfo))
        return "Error";

      var ics = Keys.IntegerCoordinateSystemInfo.Get(ctx);
      var with = new WithValue(this, ctx);
      ics.DoGeneric(with);
      return with.Result;
    }

    protected abstract bool IsAvailable<T, Q>(T cs, Context ctx)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;

    protected abstract string GetValue<T, Q>(T cs, Context ctx)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate;

    private class WithAvailable : IIntegerCoordinateSystemWith
    {
      private readonly IntegerCoordinateStepCustomParameterBase myBase;
      private readonly Context myCtx;
      public bool Result { get; private set; }

      public WithAvailable(IntegerCoordinateStepCustomParameterBase @base, Context ctx)
      {
        myBase = @base;
        myCtx = ctx;
      }

      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        Result = myCtx.ContainsKey(Keys.GetGraphComponents<Q>()) && myBase.IsAvailable<T,Q>(system, myCtx);
      }
    }

    private class WithValue: IIntegerCoordinateSystemWith
    {
      private readonly IntegerCoordinateStepCustomParameterBase myBase;
      private readonly Context myCtx;
      public string Result { get; private set; }

      public WithValue(IntegerCoordinateStepCustomParameterBase @base, Context ctx)
      {
        myBase = @base;
        myCtx = ctx;
      }

      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate
      {
        Result = myBase.GetValue<T,Q>(system, myCtx);
      }
    }
  }
}