using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;

namespace DSIS.SimpleRunner
{
  public abstract class BuilderBase<T> : ComputationBuilderBase<T> 
    where T : BuilderData, ICloneable<T> 

  {
    protected sealed override void ComputeAll(T computationData)
    {
      var sys = computationData;
      var aa = new AgregateAction(x => BuildGraph(x, sys));
      aa.Apply(new Context());
    }

    protected abstract void BuildGraph(IActionGraphBuilder2 bld, T sys);
  }
}