using System.Windows.Forms;
using guiControls.Progress;
using guiKernel2.Actions;

namespace gui2.Progress
{
	/// <summary>
	/// Summary description for ProgressBarNotificationAdapder.
	/// </summary>
	public class ProgressBarNotificationAdapter 
	{
		private SmartProgressBar progressBar;

		public ProgressBarNotificationAdapter(SmartProgressBar progressBar, ProgressBarInfo adapter)
		{
			this.progressBar = progressBar;
			
			adapter.NewLength += new ProgressBarNewLength(newLength);
			adapter.Tick +=new ProgressBarTick(tick);
		}

		private void newLength(int length)
		{			
			progressBar.LowerBound = 0;
			progressBar.Value = 0;
			progressBar.UpperBound = length;
			
			Application.DoEvents();
		}

		private void tick()
		{
			progressBar.Value++;
		}
	
	}
}
