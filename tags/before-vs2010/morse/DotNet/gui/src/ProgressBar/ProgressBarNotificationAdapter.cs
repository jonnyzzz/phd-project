using System;
using System.Windows.Forms;
using MorseKernelATL;

namespace gui.ProgressBar
{
	/// <summary>
	/// Summary description for ProgressBarNotificationAdapder.
	/// </summary>
	public class ProgressBarNotificationAdapter : IProgressBarNotification
	{
		private SmartProgressBar progressBar;

		public ProgressBarNotificationAdapter(SmartProgressBar progressBar)
		{
			this.progressBar = progressBar;
		}

		public int Length()
		{
			return progressBar.UpperBound - progressBar.LowerBound;
		}

		public void Next(int nSteps)
		{
			Application.DoEvents();
			progressBar.Value += nSteps;
		}

		public bool NeedStop()
		{
			return false;
		}

		public void Start()
		{
			progressBar.Value = 0;
			if (OnStart != null) OnStart(this);
		}

		public void Finish()
		{
			progressBar.Value = 0;
			if (OnFinish != null) OnFinish(this);
		}


		public delegate void OnStartDelegate(ProgressBarNotificationAdapter adapter);
		public delegate void OnFinishDelegate(ProgressBarNotificationAdapter adapter);

		public event OnStartDelegate OnStart;
		public event OnFinishDelegate OnFinish;			
	}
}
