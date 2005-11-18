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

        public ProgressBarNotificationAdapter(SmartProgressBar progressBar, ProgressBarInfo adapter)
        {
            this.progressBar = progressBar;

            adapter.NewLength += new ProgressBarNewLength(newLength);
            adapter.Tick += new ProgressBarTick(tick);
        }

        private void newLength(int length)
        {
            progressBar.LowerBound = 0;
            progressBar.Value = 0;
            progressBar.UpperBound = length;

            System.Windows.Forms.Application.DoEvents();
        }

        private void tick()
        {
            progressBar.Value++;
        }

    }
}