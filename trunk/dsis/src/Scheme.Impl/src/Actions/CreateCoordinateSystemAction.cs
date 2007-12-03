using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;
using DSIS.IntegerCoordinates.Generated;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions
{
  public class CreateCoordinateSystemAction : ActionBase
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return
        CheckContext(ctx, ContextMissmatchCheck.Create(Keys.SystemSpaceKey, ""),
                     ContextMissmatchCheck.Create(Keys.SubdivisionKey, "")
          );
    }


    protected override void Apply(Context ctx, Context result)
    {
      ISystemSpace info = ctx.Get(Keys.SystemSpaceKey);
      long[] subd = ctx.Get(Keys.SubdivisionKey);
      IIntegerCoordinateFactory factory = GeneratedIntegerCoordinateSystemManager.Instance.CreateSystem(info.Dimension);
      IIntegerCoordinateSystemInfo sys = factory.Create(info, subd);

      result.Set(Keys.IntegerCoordinateSystemInfo, sys);
      sys.DoGeneric(new SetContext(result));
    }

    private class SetContext : IIntegerCoordinateSystemWith
    {
      private readonly Context ctx;

      public SetContext(Context ctx)
      {
        this.ctx = ctx;
      }

      public void Do<T, Q>(T system) where T : IIntegerCoordinateSystem<Q> where Q : IIntegerCoordinate<Q>
      {
      }
    }
  }
}