using System;
using System.Windows.Forms;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.UI.Application.Progress
{
  public partial class ProgressBarControl : UserControl
  {
    private ProgressImpl myProgress;
    private DateTime myLastUpdatedTime = DateTime.MinValue;

    public ProgressBarControl()
    {
      InitializeComponent();
      SetDisabled();
    }

    public ProgressImpl ProgressModel
    {
      set
      {
        if (myProgress == value) return;
        Unsubscribe(myProgress);
        var pi = new BackDelegatingProgress(value) {Maximum = 1000};
        Subscribe(pi);
        myProgress = pi;
      }
    }

    private void Subscribe(ProgressImpl progress)
    {
      myProgressBar.Minimum = 0;

      UpdateProgressValue(progress);
      UpdateProgressText(progress);

      progress.MaximumChanged += delegate { UpdateProgressValue(progress); };
      progress.ValueChanged += delegate { UpdateProgressValue(progress); };
      progress.TextChanged += delegate { UpdateProgressText(progress); };
      myStartInfiniteTimer.Enabled = true;
      myProgressBar.Enabled = true;
    }

    private void Unsubscribe(ProgressImpl progress)
    {
      SetDisabled();
      if (progress == null)
        return;
      

      progress.MaximumChanged -= delegate { UpdateProgressValue(progress); };
      progress.ValueChanged -= delegate { UpdateProgressValue(progress); };
      progress.TextChanged -= delegate { UpdateProgressText(progress); };
    }

    private void SetDisabled()
    {
      myStartInfiniteTimer.Enabled = false;
      myProgressBar.Enabled = false;
      myMainLabel.Text = "Idle";
    }

    private void UpdateProgressValue(ProgressImpl progress)
    {
      this.InvokeAction(delegate
                          {
                            myProgressBar.Maximum = (int) progress.Maximum;
                            myProgressBar.Value = (int) progress.Value;
                            myLastUpdatedTime = DateTime.Now;
                          });
    }

    private void UpdateProgressText(IProgressInfoLight progress)
    {
      this.InvokeAction(delegate
                          {
                            myMainLabel.Text = progress.Text;
                            myLastUpdatedTime = DateTime.Now;
                          });
    }

    private void myStartInfiniteTimer_Tick(object sender, EventArgs e)
    {
      if (myLastUpdatedTime + TimeSpan.FromMilliseconds(500) < DateTime.Now)
      {
        myProgressBar.Style = ProgressBarStyle.Marquee;
      } else
      {
        myProgressBar.Style = ProgressBarStyle.Continuous;
      }
    }
  }
}