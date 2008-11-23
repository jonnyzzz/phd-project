using System;
using DSIS.Graph.Entropy.Impl.JVR;
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

    public IAction CreateComputeAction(object options)
    {
      return new JVRMeasureAction((JVRMeasureOptions) options);
    }
  }
}