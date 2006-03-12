using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Container;

namespace EugenePetrenko.Gui2.Kernell2.ActionFactory.ActionInfos
{
    /// <summary>
    /// Summary description for ActionStateRef.
    /// </summary>
    /// 

    public class ActionStateRef
    {
        private ActionRef actionRef;
        private bool isEnabled;

        public ActionStateRef(ActionRef actionRef, bool isEnabled)
        {
            this.actionRef = actionRef;
            this.isEnabled = isEnabled;
        }

        public ActionWrapper CreateInstance()
        {
            if (isEnabled)
            {
                return actionRef.CreateInstance();
            }
            else
            {
                return Core.Instance.ActionWrapperFactory.CreateDisabledAction(
						actionRef.ActionCaption,
						actionRef.ActionDetail
					);
            }
        }

        public ActionRef ActionRef
        {
            get { return actionRef; }
        }

        public bool Enabled
        {
            get { return isEnabled; }
        }
    }
}