using System;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Objects.Systemx;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  [ComputeInveriantMeasureComponent]
  public class JVRMeasureActionFactory : IComputeInveriantMeasureFactory
  {
    public Type OptionsObjectType
    {
      get { return typeof(JVRMeasureOptions); }
    }

    public bool Compatible(Context ctx)
    {
      return new JVRMeasureAction(new JVRMeasureOptions()).Compatible(ctx).Count == 0;
    }

    public IAction CreateComputeAction(object options)
    {
      return new JVRMeasureAction((JVRMeasureOptions) options);
    }

    public string FactoryName
    {
      get { return "JVR Measure"; }
    }
  }
}