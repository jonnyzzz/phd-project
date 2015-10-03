using System;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  [ComputeInveriantMeasureComponent]
  public class EigenActionFactory : IComputeInveriantMeasureFactory
  {
    public Type OptionsObjectType
    {
      get { return typeof (EigenEntropyOptions); }
    }

    public string FactoryName
    {
      get { return "Eigen value entropy"; }
    }

    public bool Compatible(Context ctx)
    {
      return new EigenEntropyAction().Compatible(ctx).Count == 0;
    }

    public IAction CreateComputeAction(object options)
    {
      return new EigenEntropyAction((EigenEntropyOptions) options);
    }
  }
}