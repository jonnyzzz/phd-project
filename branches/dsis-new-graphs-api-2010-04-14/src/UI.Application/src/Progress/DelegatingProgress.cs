namespace DSIS.UI.Application.Progress
{
  public class DelegatingProgress : ProgressImpl
  {
    public DelegatingProgress(ProgressImpl info, double outerWeight)
    {
      var oldValue = Value;
      ValueChanged += delegate
                        {
                          var dValue = Value - oldValue;
                          if (Maximum > 0)
                          {
                            info.Tick(dValue/Maximum*outerWeight);
                          }
                          oldValue = Value;
                        };
      TextChanged += delegate { info.Text = Text; };
      info.Interrupted += delegate { IsInterrupted = info.IsInterrupted; };
    }
  }
}