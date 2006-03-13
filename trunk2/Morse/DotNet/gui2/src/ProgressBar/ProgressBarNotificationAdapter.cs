using System.Windows.Forms;
using EugenePetrenko.Gui2.Controls.Progress;
using EugenePetrenko.Gui2.Kernell2.Actions;

namespace EugenePetrenko.Gui2.Application.Progress
{
    /// <summary>
    /// Summary description for ProgressBarNotificationAdapder.
    /// </summary>
    public class ProgressBarNotificationAdapter
    {
        private SmartProgressBar progressBar;
		private Form threadOwnerForm;

        public ProgressBarNotificationAdapter(SmartProgressBar progressBar, ProgressBarInfo adapter)
        {
            this.progressBar = progressBar;
			threadOwnerForm = progressBar.FindForm();

            adapter.NewLength += new ProgressBarNewLength(newLength);
            adapter.Tick += new ProgressBarTick(tick);
        }

		private delegate void NewLengthDelegate(int length);
		private delegate void TickDelegate();

        private void newLength(int length)
        {
			if (threadOwnerForm.InvokeRequired)
				threadOwnerForm.BeginInvoke(new NewLengthDelegate(newLength), new object[]{length});
			else 
			{
			
				progressBar.LowerBound = 0;
				progressBar.Value = 0;
				progressBar.UpperBound = length;
			}
        }

        private void tick()
        {
			if (threadOwnerForm.InvokeRequired) 
				threadOwnerForm.BeginInvoke(new TickDelegate(tick), new object[0]);
			else
				progressBar.Value++;
        }

    }
}