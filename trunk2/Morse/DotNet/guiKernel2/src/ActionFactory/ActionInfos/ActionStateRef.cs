using System;
using guiKernel2.Actions;
using guiKernel2.Container;

namespace guiKernel2.ActionFactory.ActionInfos
{
	/// <summary>
	/// Summary description for ActionStateRef.
	/// </summary>
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
            } else
            {
                return Core.Instance.ActionWrapperFactory.CreateDisabledAction(
                    Core.Instance.ActionNamingFactory.FindActionCaption(actionRef.ActionName),
                    Core.Instance.ActionNamingFactory.FindActionComment(actionRef.ActionName));
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
