using Eugene.Petrenko.Gui2.MethodComparer.Actions;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace Eugene.Petrenko.Gui2.MethodComparer.Parameters
{
  public class IteratedMethodsFactory
  {
    private IMethodParameters myPars;
    private string fullPath;
    private ResultSet initialSet;

    public IteratedMethodsFactory(IMethodParameters pars, string fullPath)
    {
      myPars = pars;
      this.fullPath = fullPath;
      initialSet = pars.InitialResultSet;
    }

    private IteratingAction CreateAction(string name, IMethodParameters pars, params IDefinedAction[] act)
    {
      ExportToPointsDefinedAction action = new ExportToPointsDefinedAction(pars, name, fullPath);
      return new IteratingAction(initialSet, name, pars.NumberOfSteps, pars.DevideUnsimmetric, action, act);
    }

    public IteratingAction LinearAction()
    {
      return CreateAction("Linear", myPars, new LinearMethodDefinedAction(myPars), new TarjanDefinedAction(myPars));
    }

    public IteratingAction PointMethodAction()
    {
      return CreateAction("PointMethod", myPars, new PointMethodDefinedAction(myPars), new TarjanDefinedAction(myPars));
    }

    public IteratingAction OverlapingPointMethodAction()
    {
      return CreateAction("OverlapingPointMethod", myPars, new OverlapedPointMethod(myPars), new TarjanDefinedAction(myPars));
    }

    public IteratingAction AdaptiveMethodAction()
    {
      return CreateAction("AdaptiveMethod", myPars, new AdaptiveMethodDefinedAction(myPars), new TarjanDefinedAction(myPars));
    }

    public IteratingAction[] Task()
    {
      return new IteratingAction[]
        {
          LinearAction(),
          PointMethodAction(),
          OverlapingPointMethodAction(),
          AdaptiveMethodAction()
        };
    }
  }
}