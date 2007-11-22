using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer.Actions
{
  /// <summary>
  /// Summary description for TarjanDefinedAction.
  /// </summary>
  public class TarjanDefinedAction : DefinedActionBase, ITarjanParameters
  {
    public TarjanDefinedAction(IMethodParameters methodParameters) : base(methodParameters)
    {
    }

    public override string Name
    {
      get { return "Tarjan process"; }
    }

    public override IAction Action
    {
      get { return new CTarjanActionClass(); }
    }

    public bool NeedEdgeResolve()
    {
      return GlobalParameters.NeedResolveEdges();
    }
  }
}