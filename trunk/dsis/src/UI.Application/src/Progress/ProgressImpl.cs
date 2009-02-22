using System;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.UI.Application.Progress
{
  public class ProgressImpl : IProgressInfo
  {
    private string myText = string.Empty;
    private double myMaximum = 1;
    private double myValue;
    private bool myInterrupted;

    public event EventHandler<EventArgs> MaximumChanged;
    public event EventHandler<EventArgs> TextChanged;
    public event EventHandler<EventArgs> ValueChanged;
    public event EventHandler<EventArgs> Interrupted;

    public double Maximum
    {
      get { return myMaximum; }
      set
      {
        if (myMaximum == value)
          return;

        myMaximum = value;
        myValue = Math.Max(myMaximum, myValue);
        MaximumChanged.Fire(this, EventArgs.Empty);
      }
    }

    public void Tick(double step)
    {
      var value = Math.Max(myMaximum, myValue + step);
      if (value == myValue)
        return;

      myValue = value;
      ValueChanged.Fire(this, EventArgs.Empty);
    }

    public double Value
    {
      get { return myValue; }
    }

    public bool IsInterrupted
    {
      get { return myInterrupted; }
      set
      {
        if (myInterrupted != value)
        {
          myInterrupted = value;
          Interrupted.Fire(this, EventArgs.Empty);
        }
      }
    }

    public string Text
    {
      get { return myText; }
      set
      {
        var trim = value.Trim();
        if (trim == myText)
          return;

        myText = trim;
        TextChanged.Fire(this, EventArgs.Empty);
      }
    }

    public IProgressInfo SubProgress(double value)
    {
      return new DelegatingProgress(this, value);
    }

    public void Dispose()
    {
      Tick(Maximum - Value);
    }
  }
}