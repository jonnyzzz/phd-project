using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer
{
  /// <summary>
  /// Summary description for ActionWrapper.
  /// </summary>
  public class ActionWrapper : EugenePetrenko.Gui2.Kernell2.Actions.ActionWrapper
  {
    private readonly IAction action;
    private readonly IParameters parameters;

    public ActionWrapper(IAction action, IParameters parameters, string name) : base(name, true)
    {
      this.action = action;
      this.parameters = parameters;
    }

    protected override IParameters Parameters
    {
      get { return parameters; }
    }

    protected override IAction CreateAction()
    {
      return action;
    }
  }
}