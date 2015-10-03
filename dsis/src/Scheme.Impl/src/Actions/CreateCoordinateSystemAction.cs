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
      IIntegerCoordinateFactoryEx factoryEx = GeneratedIntegerCoordinateSystemManager.Instance.CreateSystem(info.Dimension);
      IIntegerCoordinateSystemInfo sys = factoryEx.Create(info, info.InitialSubdivision);

      result.Set(Keys.IntegerCoordinateSystemInfo, sys);
    }
  }
}