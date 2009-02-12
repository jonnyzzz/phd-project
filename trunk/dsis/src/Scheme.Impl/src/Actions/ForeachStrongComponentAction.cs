using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions
{
  public class ForeachStrongComponentAction : IntegerCoordinateSystemActionBase3, ILoopAction
  {
    private readonly IAction myBody;
    private readonly string myKey;

    public ForeachStrongComponentAction(string key, ConstructGraph cg)
    {
      myKey = key;
      myBody = cg(this);
      
    }

    public ForeachStrongComponentAction(string key, IAction body) : this(key, x => body)
    {
    }

    public Key<LoopIndex> Key
    {
      get { return LoopIndex.Create(myKey); }
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(EmptyArray<ContextMissmatchCheck>.Instance, Create(Keys.GetGraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      var comps = Keys.GetGraphComponents<Q>().Get(input);
      var index = 0;
      foreach (var _info in comps.Components)
      {
        var info = _info;
        var ag = new ActionGraph();

        var dIndex = index;
        var ac = new UpdateContextAction(
          delegate(Context _, Context ctx)
            {
              IGraph<Q> graph = comps.AsGraph(new[] {info});

              ctx.AddAll(input);
              
              Keys.Graph<Q>().Set(ctx, graph);
              Keys.GetGraphComponents<Q>().Set(ctx, graph.ComputeStrongComponents(NullProgressInfo.INSTANCE));
              Key.Set(ctx, new LoopIndex(dIndex, comps.ComponentCount));
            });

        var save = new UpdateContextAction((@in, _) => output.AddAll(@in));

        ag.AddEdge(ac, myBody);
        ag.AddEdge(myBody, save);

        ag.Execute();

        index++;
      }
    }
  }
}