using System;
using System.Collections.Generic;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class DrawEntropyMeasureActionBase : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      if (system.Dimension != 2)
        throw new Exception("Dimension is assumend to be 2");

      return ColBase(base.Check<T, Q>(system, ctx),
                     Create(FileKeys.WorkingFolderKey),
                     Create(Keys.GraphMeasure<Q>()
                       ));
    }    
  }
}