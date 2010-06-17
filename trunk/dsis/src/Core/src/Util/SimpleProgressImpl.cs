using System;

namespace DSIS.Core.Util
{
  public class SimpleProgressImpl : IProgressInfo
  {
    public double Maximum { get; set; }
    public double Value { get; set; }
    public bool IsInterrupted { get; set; }
    public string Text { get; set; }

    public void Dispose()
    {
    }

    public void Tick(double step)
    {
      Value = Math.Min(Math.Max(Value + step, Maximum), 0);
    }
    public IProgressInfo SubProgress(double weight)
    {
      return new SimpleSubProgressImpl(this, weight);
    }
  }
}