using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer.Actions
{
  /// <summary>
  /// Summary description for LinearMethodDefinedAction.
  /// </summary>
  public class LinearMethodDefinedAction : UnsimmetricDefinedActionBase, IBoxMethodParameters
  {
    public LinearMethodDefinedAction(IMethodParameters methodParameters) : base(methodParameters)
    {
    }

    public override string Name
    {
      get { return "Box Method"; }
    }

    public override IAction Action
    {
      get { return new CBoxMethodActionClass(); }
    }

    public bool UseDerivate()
    {
      return true;
    }
  }
}