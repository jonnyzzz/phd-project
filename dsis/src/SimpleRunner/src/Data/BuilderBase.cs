using System.Collections.Generic;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;
using DSIS.SimpleRunner.Computation;
using DSIS.Utils;

namespace DSIS.SimpleRunner.Data
{
  public abstract class BuilderBase<T> : ComputationBuilderBase<T> 
    where T : BuilderData, ICloneable<T> 

  {

    protected override void SortTasks(List<T> queue)
    {
      queue.Sort((x, y) => x.repeat.CompareTo(y.repeat));
    }


    protected sealed override void ComputeAll(T computationData)
    {
      var sys = computationData;
      var aa = new AgregateAction(x => BuildGraph(x, sys));
      aa.Apply(new Context());
    }

    protected abstract void BuildGraph(IActionGraphBuilder2 bld, T sys);
  }
}