using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions
{
  public class MergeComponetsAction : IntegerCoordinateSystemActionBase
  {
    protected override With Create(Context @in, Context @out)
    {
      return new With2(@in, @out);
    }

    protected override Check Create(Context @in)
    {
      return new Check2(@in);
    }

    protected class Check2 : Check
    {
      public Check2(Context context) : base(context)
      {
      }

      public override void Do<T, Q>(T system)
      {
        base.Do<T, Q>(system);
        Result.Add(Create(Keys.GraphComponents<Q>()));
      }
    }

    protected class With2 : With
    {
      public With2(Context context, Context outputContext) : base(context, outputContext)
      {
      }

      public override void Do<T, Q>(T system)
      {
        IGraphStrongComponents<Q> comps = Keys.GraphComponents<Q>().Get(myContext);
        CountEnumerable<Q> data = comps.GetCoordinates(new List<IStrongComponentInfo>(comps.Components));

        Keys.CellsEnumerationKey<Q>().Set(myOutputContext, data);
      }
    }
  }
}