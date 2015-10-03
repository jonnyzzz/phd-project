using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.Actions2
{
	/// <summary>
	/// Summary description for AbstractAction.
	/// </summary>
	public abstract class AbstractAction
	{
	    public AbstractAction(IAction action)
	    {
	        this.action = action;
	    }

	    public abstract string Name { get; }
        public abstract string Description { get; }        
		                
        public abstract void SubmitParameters(IParametersIU ui);
        public abstract bool ProduceResult { get; }

        public bool CanDo(ResultSet set)
        {
            return action.CanDo(set.ToResultSet);
        }

        public ResultSet Do(ResultSet set, IProgressBarInfo info)
        {
            IParameters parameters = Parameters;
            action.SetActionParameters(parameters);
            action.SetProgressBarInfo(progressBarInfo.GetProgressBarInfo(this));
            if (!action.CanDo(input.ToResultSet))
            {
                throw new ActionPerformException("CanDo call returned FALSE");
            }
            return DoActionInteranl(input);
        }

        private readonly IAction action;

        
	}
}
