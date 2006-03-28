using Eugene.Petrenko.Gui2.MethodComparer.Actions;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace Eugene.Petrenko.Gui2.MethodComparer.Parameters
{
	public class IteratedMethodsFactory
	{
        private IMethodParameters pars;
	    private string fullPath;
	    private ResultSet initialSet;

	    public IteratedMethodsFactory(IMethodParameters pars, string fullPath)
	    {
	        this.pars = pars;
	        this.fullPath = fullPath;
            initialSet = pars.InitialResultSet;
	    }

	    private IteratingAction CreateAction(string name, IMethodParameters pars, params IDefinedAction[] act)
        {
	        ExportToPointsDefinedAction action = new ExportToPointsDefinedAction(pars, name, fullPath);
	        return new IteratingAction(initialSet, name,  pars.NumberOfSteps, action, act);
        }

		public IteratingAction LinearAction()
		{
            return CreateAction("Linear", pars,  new LinearMethodDefinedAction(pars), new TarjanDefinedAction(pars));		    
		}

        public IteratingAction PointMethodAction()
        {
            return CreateAction("PointMethod", pars, new PointMethodDefinedAction(pars), new TarjanDefinedAction(pars));
        }

        public IteratingAction OverlapingPointMethodAction()
        {
            return CreateAction("OverlapingPointMethod", pars, new OverlapedPointMethod(pars), new TarjanDefinedAction(pars));
        }

        public IteratingAction AdaptiveMethodAction() {
            return CreateAction("AdaptiveMethod", pars, new AdaptiveMethodDefinedAction(pars), new TarjanDefinedAction(pars));
        }

        public IteratingAction[] Task()
        {
            return new IteratingAction[] {
                    LinearAction(),
                    PointMethodAction(),
                    OverlapingPointMethodAction(),
                    AdaptiveMethodAction()
            };
        }
        
    }
}
