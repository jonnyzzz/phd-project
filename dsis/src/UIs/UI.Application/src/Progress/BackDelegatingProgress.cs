using System;

namespace DSIS.UI.Application.Progress
{
  public class BackDelegatingProgress : ProgressImpl
  {
    private readonly ProgressImpl myInfo;
    private double myOldValue;
    public BackDelegatingProgress(ProgressImpl info)
    {
      myInfo = info;
      myOldValue = info.Value;

      info.ValueChanged += OnValueChanged;
      info.MaximumChanged += OnMaximumChanged;

      Interrupted += delegate { info.IsInterrupted = IsInterrupted; };
      info.TextChanged += delegate { Text = info.Text; };
      Text = info.Text;
    }

    private void OnMaximumChanged(object sender, EventArgs e)
    {
      var value = myInfo.Maximum > 0 ? myInfo.Value/myInfo.Maximum*Maximum : 0;
      Tick(value - myOldValue);
      myOldValue = value;
    }

    private void OnValueChanged(object sender, EventArgs e)
    {
      var dValue = myInfo.Value - myOldValue;
      if (myInfo.Maximum > 0)
      {
        Tick(dValue / myInfo.Maximum * Maximum);
      }
      myOldValue = myInfo.Value;
    }

    public ProgressImpl BaseProgressInfo
    {
      get { return myInfo; }
    }
  }
}