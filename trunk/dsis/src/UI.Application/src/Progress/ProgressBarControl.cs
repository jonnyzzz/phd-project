using System;
using System.Windows.Forms;
using DSIS.Core.Util;
using DSIS.UI.UI;

namespace DSIS.UI.Application.Progress
{
  public partial class ProgressBarControl : UserControl
  {
    private readonly IInvocator myInvocator;
    private BackDelegatingProgress myProgress;
    private IDisposable myProgressTimer;

    private DateTime myLastUpdatedTime = DateTime.MinValue;

    public ProgressBarControl(IInvocator invocator)
    {
      myInvocator = invocator;

      InitializeComponent();
      SetDisabled();
    }

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
      } else {
        myProgress = null;
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
      myProgressBar.Enabled = true;

      StartTimer();
    }

    private void Unsubscribe(ProgressImpl progress)
    {
      SetDisabled();
      if (progress == null)
        return;

      progress.MaximumChanged -= delegate { UpdateProgressValue(progress); };
      progress.ValueChanged -= delegate { UpdateProgressValue(progress); };
      progress.TextChanged -= delegate { UpdateProgressText(progress); };

      SetDisabled();
    }

    private void SetDisabled()
    {
      StopTimer();
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
                                    myProgressBar.Value = (int) progress.Value;
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
  }
}