using System.Collections.Generic;
using DSIS.Core.System;
using DSIS.LineIterator;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Line
{
  public class LineAction : LineBaseAction
  {
    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, base.Compatible(ctx), Create(Keys.SystemInfoKey), Create(Keys.SystemSpaceKey));
    }

    protected override void Apply(ILine line, Context ctx, Context result)
    {      
      ISystemInfo system = Keys.SystemInfoKey.Get(ctx);
      ISystemSpace space = Keys.SystemSpaceKey.Get(ctx);

      if (line.Count > 0)
      {
        (line = line.Clone()).Iterate(space, system);
      }

      Keys.LineKey.Set(result, line);
      Keys.SystemInfoKey.Set(result, system);
    }
  }  
}