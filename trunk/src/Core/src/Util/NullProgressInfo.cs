using System;

namespace DSIS.Core.Util
{
  public class NullProgressInfo : IProgressInfo
  {
    public static readonly IProgressInfo INSTANCE = new NullProgressInfo();

    private double myMinimum = 0;
    private double myMaximum = 1;
    private double myValue = 0;

    public double Minimum
    {
      get { return myMinimum; }
      set { myMinimum = value; }
    }

    public double Maximum
    {
      get { return myMaximum; }
      set { myMaximum = value; }
    }

    public double Value
    {
      get { return myValue; }
      set { myValue = value; }
    }

    public void Tick(double step)
    {
      myValue += step;
    }

    public bool SupportsSteppingProgres
    {
      get { return false; }
    }

    public bool IsInterrupted
    {
      get { return false; }
    }
  }
}