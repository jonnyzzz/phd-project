using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.Actions
{
    /// <summary>
    /// Summary description for ActionWrapper.
    /// </summary>
    public abstract class ActionWrapper : AttributeHolder
    {
        private IAction action;
        private readonly bool isChainLeaf;
        private string actionName;

        public ActionWrapper(string actionName, bool isChainLeaf)
        {
            this.isChainLeaf = isChainLeaf;
            this.actionName = actionName;
            this.action = CreateAction();
        }

        public bool IsChainLeaf
        {
            get { return isChainLeaf; }
        }

        public string ActionName
        {
            get { return actionName; }
        }


        protected abstract IParameters Parameters { get; }
        protected abstract IAction CreateAction();


        public virtual bool PublishResults
        {
            get { return true; }
        }

        public ResultSet Do(ResultSet input, ProgressBarInfo progressBarInfo)
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

        protected virtual ResultSet DoActionInteranl(ResultSet input)
        {
            return ResultSet.FromResultSet(action.Do(input.ToResultSet));
        }

        public string ActionMappingName
        {
            get { return MyAttribute.ActionInterface.Name; }
        }

        public string ActionParametersName
        {
            get { return MyAttribute.ParametersInterface.Name; }
        }

        public IAction Action
        {
            get { return action; }
        }

        public override string ToString()
        {
            return string.Format("ActionWrapper class [action = {0}, params = {1}]", ActionMappingName, ActionParametersName);
        }

    }
}