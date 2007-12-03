using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl
{
  public class ChainRecurrenctSimbolicImageAction : IntegerCoordinateSystemActionBase
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
        Result.Add(Create(Keys.Graph<Q>()));
        Result.Add(Create(Keys.ProgressInfoKey));
      }
    }

    protected class With2 : With
    {
      public With2(Context context, Context outputContext) : base(context, outputContext)
      {
      }

      public override void Do<T, Q>(T system)
      {
        IProgressInfo info = Keys.ProgressInfoKey.Get(myContext);
        IGraphWithStrongComponent<Q> graph = Keys.Graph<Q>().Get(myContext);
        IGraphStrongComponents<Q> comps = graph.ComputeStrongComponents(info);

        Keys.GraphComponents<Q>().Set(myOutputContext, comps);
      }
    }
  }
}