using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions
{
  public abstract class CreateCoordinateSystemActionBase : ActionBase
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, Create(Keys.SystemSpaceKey));
    }

    protected override void Apply(Context ctx, Context result)
    {
      ISystemSpace info = ctx.Get(Keys.SystemSpaceKey);
      IIntegerCoordinateSystem sys = CreateSystem(info);

      result.Set(Keys.IntegerCoordinateSystemInfo, sys);
    }

    protected abstract IIntegerCoordinateSystem CreateSystem(ISystemSpace info);
  }
}