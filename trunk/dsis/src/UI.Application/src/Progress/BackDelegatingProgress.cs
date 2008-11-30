namespace DSIS.UI.Application.Progress
{
  public class BackDelegatingProgress : ProgressImpl
  {
    private readonly ProgressImpl myInfo;

    public BackDelegatingProgress(ProgressImpl info)
    {
      myInfo = info;
      var oldValue = info.Value;
      info.ValueChanged += delegate
                             {
                               var dValue = info.Value - oldValue;
                               if (info.Maximum > 0)
                               {
                                 Tick(dValue/info.Maximum*Maximum);
                               }
                               oldValue = info.Value;
                             };
      Interrupted += delegate { info.IsInterrupted = IsInterrupted; };
      info.TextChanged += delegate { Text = info.Text; };
      Text = info.Text;
    }

    public ProgressImpl BaseProgressInfo
    {
      get { return myInfo; }
    }
  }
}