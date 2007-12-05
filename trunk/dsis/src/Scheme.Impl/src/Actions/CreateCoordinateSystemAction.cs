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
      return CheckContext(ctx, Create(Keys.SystemSpaceKey));
    }

    protected override void Apply(Context ctx, Context result)
    {
      ISystemSpace info = ctx.Get(Keys.SystemSpaceKey);
      IIntegerCoordinateFactory factory = GeneratedIntegerCoordinateSystemManager.Instance.CreateSystem(info.Dimension);
      IIntegerCoordinateSystemInfo sys = factory.Create(info, info.InitialSubdivision);

      result.Set(Keys.IntegerCoordinateSystemInfo, sys);
    }
  }
}