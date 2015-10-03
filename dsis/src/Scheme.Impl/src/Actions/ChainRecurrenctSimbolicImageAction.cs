using System;
using DSIS.Core.Util;
using DSIS.Graph.Abstract.Algorithms;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions
{
  public class ChainRecurrenctSimbolicImageAction : IntegerCoordinateSystemActionBase2Ex
  {
    protected override void GetChecks<T, Q>(T system, Action<ContextMissmatchCheck> addCheck)
    {
      addCheck(Create(Keys.Graph<Q>()));
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IProgressInfo info = NullProgressInfo.INSTANCE;
      var graph = Keys.Graph<Q>().Get(input);
      var comps = graph.ComputeStrongComponents(info);

      Keys.GetGraphComponents<Q>().Set(output, comps);
    }    
  }
}