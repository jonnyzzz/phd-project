namespace DSIS.Core.Util
{
  public sealed class NullProgressInfo : IProgressInfo
  {
    public static readonly IProgressInfo INSTANCE = new NullProgressInfo();

    private double myValue;

    public bool IsInterrupted
    {
      get { return false; }
    }

    public IProgressInfo SubProgress(double value)
    {
      return new NullProgressInfo();
    }

    public string Text { get; set; }

    public double Maximum { get; set; }

    public void Tick(double step)
    {
      myValue += step;
    }
  }
}