using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions
{
  public class SystemInfoAction : ActionBase
  {
    private readonly ISystemInfo mySystemInfo;
    private readonly ISystemSpace mySystemSpace;

    public SystemInfoAction(ISystemInfo systemInfo, ISystemSpace systemSpace)
    {
      mySystemInfo = systemInfo;
      mySystemSpace = systemSpace;
    }

    protected override void Apply(Context ctx, Context result)
    {
      Keys.SystemInfoKey.Set(result, mySystemInfo);
      Keys.SystemSpaceKey.Set(result, mySystemSpace);
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }
  }
}