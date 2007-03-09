namespace DSIS.Core.Util
{
  public sealed class NullProgressInfo : IProgressInfo
  {
    public static readonly IProgressInfo INSTANCE = new NullProgressInfo();

    private double myMinimum = 0;
    private double myMaximum = 1;
    private double myValue = 0;

    #region IProgressInfo Members

    public bool IsInterrupted
    {
      get { return false; }
    }

    public double Maximum
    {
      get { return myMaximum; }
      set { myMaximum = value; }
    }

    public double Minimum
    {
      get { return myMinimum; }
      set { myMinimum = value; }
    }

    public bool SupportsSteppingProgres
    {
      get { return false; }
    }

    public void Tick(double step)
    {
      myValue += step;
    }

    public double Value
    {
      get { return myValue; }
      set { myValue = value; }
    }

    #endregion
  }
}