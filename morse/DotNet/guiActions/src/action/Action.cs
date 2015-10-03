using EugenePetrenko.Gui2.Actions.Parameters;
using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.Actions
{
  /// <summary>
  /// Summary description for Action.
  /// </summary>
  public abstract class Action : ActionWrapper
  {
    public Action(string caption, bool isChainLeaf) : base(caption, isChainLeaf)
    {
    }

    protected override IParameters Parameters
    {
      get { return cachedParameters; }
    }

    private IParameters cachedParameters = null;
    private ParametersControl cachedParametersControl = null;

    protected abstract ParametersControl GetParametersControlInternal(KernelNode node);

    protected void SetFakeControl(ParametersControl control)
    {
      if (cachedParametersControl != null)
      {
        cachedParametersControl.DataSubmitted -= new ParametersSubmitted(DataSubmitted);
      }
      cachedParametersControl = control;
      cachedParametersControl.DataSubmitted += new ParametersSubmitted(DataSubmitted);
      DataSubmitted(cachedParametersControl.CachedParameters);
    }

    public ParametersControl GetParametesControl(KernelNode node)
    {
//			if (cachedParametersControl == null)
      {
        if (cachedParameters != null)
        {
          cachedParametersControl.DataSubmitted -= new ParametersSubmitted(DataSubmitted);
        }
        cachedParametersControl = GetParametersControlInternal(node);
        cachedParameters = null;
        cachedParametersControl.DataSubmitted += new ParametersSubmitted(DataSubmitted);
      }
      return cachedParametersControl;
    }

    private void DataSubmitted(IParameters parameters)
    {
      if (parameters == null) throw new ActionException("Parameters was NULL");
      cachedParameters = parameters;
    }
  }
}