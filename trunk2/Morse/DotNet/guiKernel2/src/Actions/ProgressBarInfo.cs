using System;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.Actions
{
    public delegate void CancelEvent();
	public interface IProgressBarListener
	{
		void NewTask(string caption, double length);
		void Tick(double value);
		void Finish();

		event CancelEvent Canceled;
	}
	
	public class EmptyProgressBarListener : IProgressBarListener
	{
		public void NewTask(string caption, double length)
		{			
		}
		public void Tick(double value)
		{
		}
		public void Finish()
		{
		}
		public event CancelEvent Canceled
		{
			add {}
			remove{ }
		}
	}

    public class ProgressBarInfo
    {
        private IProgressBarListener listener;
		private bool needStop;		

    	public ProgressBarInfo(IProgressBarListener listener)
    	{
			needStop = false;
    		this.listener = listener;
			this.listener.Canceled += new CancelEvent(listener_Canceled);
    	}

		private void listener_Canceled()
		{
			needStop = true;
		}

		public void ProcessFinished()
		{
			listener.Finish();
		}

    	public IProgressBarInfo GetProgressBarInfo(ActionWrapper actionWrapper)
        {			
            return new ProgressBarInfoImpl(this, actionWrapper.ActionName);
        }

        private class ProgressBarInfoImpl : IProgressBarInfo
        {
            private ProgressBarInfo instance;
			private string actionName;
			private int count = 0;

            public ProgressBarInfoImpl(ProgressBarInfo instance, string name)
            {
                this.instance = instance;
				actionName = name;
            }

            public void Finish()
            {
                instance.listener.Finish();
            }

            public double Length()
            {
                return 300;
            }

            public bool NeedStop()
            {
                return !instance.needStop;
            }

            public void Start()
            {
				instance.listener.NewTask(actionName + " " + (++count), Length());
            }

        	public void Next(double value)
			{
				instance.listener.Tick(value);
        	}
		}		
	}
}