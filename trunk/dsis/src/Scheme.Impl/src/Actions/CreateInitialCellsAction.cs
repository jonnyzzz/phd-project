using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl
{
  public class CreateInitialCellsAction : IntegerCoordinateSystemActionBase
  {
    protected override With Create(Context @in, Context @out)
    {
      return new With2(@in, @out);
    }

    protected class With2 : With
    {
      public With2(Context context, Context outputContext) : base(context, outputContext)
      {
      }

      public override void Do<T, Q>(T system)
      {
        Keys.CellsEnumerationKey<Q>().Set(myOutputContext, system.InitialSubdivision);
      }
    }
  }
}