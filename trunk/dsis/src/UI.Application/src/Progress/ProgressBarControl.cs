using System;
using System.Drawing;
using System.Windows.Forms;
using DSIS.Core.Util;
using DSIS.UI.UI;
using DSIS.Utils;

namespace DSIS.UI.Application.Progress
{
  public partial class ProgressBarControl : UserControl
  {
    private readonly IInvocator myInvocator;
    private BackDelegatingProgress myProgress;
    private IDisposable myProgressTimer;

    private DateTime myLastUpdatedTime = DateTime.MinValue;

    public event EventHandler<EventArgs> Interrupted;

    public ProgressBarControl(IInvocator invocator)
    {
      myInvocator = invocator;

      InitializeComponent();
      TabStop = false;
      SetDisabled();
    }

    public bool IsInterruptable { get; set; }

    public bool HasModel
    {
      get { return myProgress != null; }
    }

    public void ClearProgressIfSame(ProgressImpl progress)
    {
      if (myProgress != null && progress == myProgress.BaseProgressInfo)
      {
        SetProgressModel(null);
      }
    }

    public void SetProgressModel(ProgressImpl value)
    {
      if (myProgress == value) return;
      Unsubscribe(myProgress);
      if (value != null)
      {
        var pi = new BackDelegatingProgress(value) {Maximum = 1000};
        Subscribe(pi);
        myProgress = pi;
      }
      else
      {
        myProgress = null;
      }
    }

    private void Subscribe(ProgressImpl progress)
    {
      myProgressBar.Minimum = 0;

      UpdateProgressValue(progress);
      UpdateProgressText(progress);
      EnableCancelLink();

      progress.MaximumChanged += delegate { UpdateProgressValue(progress); };
      progress.ValueChanged += delegate { UpdateProgressValue(progress); };
      progress.TextChanged += delegate { UpdateProgressText(progress); };
      progress.Interrupted += delegate { FireInterrupted(); };
      myProgressBar.Enabled = true;

      StartTimer();
    }

    private void FireInterrupted()
    {
      Interrupted.Fire(this, EventArgs.Empty);
    }

    private void Unsubscribe(ProgressImpl progress)
    {
      SetDisabled();
      if (progress == null)
        return;

      progress.MaximumChanged -= delegate { UpdateProgressValue(progress); };
      progress.ValueChanged -= delegate { UpdateProgressValue(progress); };
      progress.TextChanged -= delegate { UpdateProgressText(progress); };
      progress.Interrupted -= delegate { FireInterrupted(); };
      myCancel.Visible = false;

      SetDisabled();
    } 

    private void SetDisabled()
    {
      StopTimer();
      myCancel.Visible = false;
      myMainLabel.Text = "Idle";
      myProgressBar.Enabled = false;
      myProgressBar.Style = ProgressBarStyle.Continuous;
      myProgressBar.Value = 0;
    }

    private void StartTimer()
    {
      myProgressTimer = myInvocator.ExecuteRepeating("Set marque", TimeSpan.FromSeconds(.5), StartMarque);
    }

    private void StopTimer()
    {
      if (myProgressTimer != null)
      {
        myProgressTimer.Dispose();
        myProgressTimer = null;
      }
    }

    private void UpdateProgressValue(ProgressImpl progress)
    {
      myInvocator.InvokeOrQueue("Progress::UpdateProgressValue",
                                delegate
                                  {
                                    myProgressBar.Maximum = (int) progress.Maximum;
                                    myProgressBar.Value = (int)Math.Min(progress.Value, progress.Maximum);
                                    myLastUpdatedTime = DateTime.Now;
                                  });
    }

    private void UpdateProgressText(IProgressInfoLight progress)
    {
      myInvocator.InvokeOrQueue("Progress::UpdateProgressText",
                                delegate
                                  {
                                    myMainLabel.Text = progress.Text;
                                    myLastUpdatedTime = DateTime.Now;
                                  });
    }

    private void StartMarque()
    {
      myProgressBar.Style =
        myLastUpdatedTime + TimeSpan.FromMilliseconds(500) < DateTime.Now
          ? ProgressBarStyle.Marquee
          : ProgressBarStyle.Continuous;
    }

    private void myCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      myProgress.IsInterrupted = true;
      myCancel.Text = "Canceled";
      myCancel.ActiveLinkColor = Color.Red;
      myCancel.Enabled = false;
    }

    private void EnableCancelLink()
    {
      myCancel.Visible = IsInterruptable;
      myCancel.Enabled = IsInterruptable;
      myCancel.Text = "Cancel";
      myCancel.ActiveLinkColor = Color.Blue;
    }
  }
}