using System.Windows.Forms;
using EugenePetrenko.Gui2.Controls.Progress;
using EugenePetrenko.Gui2.Kernell2.Actions;

namespace EugenePetrenko.Gui2.Application.Progress
{
    /// <summary>
    /// Summary description for ProgressBarNotificationAdapder.
    /// </summary>
    public class ProgressBarNotificationAdapter : IProgressBarListener
    {
        private SmartProgressBar progressBar;
    	private readonly Label label;
    	private Form threadOwnerForm;		

        public ProgressBarNotificationAdapter(SmartProgressBar progressBar, Label label)
        {
            this.progressBar = progressBar;
        	this.label = label;
        	threadOwnerForm = progressBar.FindForm();
        }
				
		public ProgressBarInfo GetProgressBarInfo()
		{
			return new ProgressBarInfo(this);
		}

		private delegate void NewTaskDelegate(string capion, double length);
		private delegate void DoubleDelegate(double v);
		private delegate void VoidDelegate();

    	public void NewTask(string caption, double length)
    	{
			if (threadOwnerForm.InvokeRequired)
				threadOwnerForm.BeginInvoke(new NewTaskDelegate(NewTask), new object[]{caption, length});
			else 
			{			
				progressBar.LowerBound = 0;
				progressBar.Value = 0;
				progressBar.UpperBound = length;
				label.Text = "Processing " + caption + "...";
			}
    	}

    	public void Tick(double value)
    	{
			if (threadOwnerForm.InvokeRequired) 
				threadOwnerForm.BeginInvoke(new DoubleDelegate(Tick), new object[]{value});
			else
				progressBar.Value += value;
    	}

    	public void Finish()
    	{
    		if (threadOwnerForm.InvokeRequired)
    		{
    			threadOwnerForm.BeginInvoke(new VoidDelegate(Finish), new object[0]);
    		} else
    		{
    			progressBar.Value = progressBar.LowerBound;
				label.Text = "";
    		}
    	}

    	public event CancelEvent Canceled{add{} remove{}}
    }
}