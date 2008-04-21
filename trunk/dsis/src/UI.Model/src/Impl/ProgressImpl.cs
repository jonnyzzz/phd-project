namespace DSIS.UI.Model.Impl
{
  public class ProgressImpl : IProgressInfo, IProgressTick
  {
    private readonly double myMax;
    private double myValue;
    private string myAction;

    public delegate void ProgressIncremented(double newValue);
    public delegate void ProgressCaptionChanged(string newCaption);

    public event ProgressIncremented OnProgressIncremented;
    public event ProgressCaptionChanged OnProgressCaptionChanged;

    public ProgressImpl(double max)
    {
      myMax = max;
    }

    public IProgressCounter SubProgress(string name, double units)
    {
      return new SubProgressImpl(this, units, name);
    }

    public void Tick(double value)
    {
    
      if (myValue <= value)
        return;

      if (OnProgressIncremented != null)
        OnProgressIncremented(myValue = value);        
    }

    public void Action(string action)
    {
      if (OnProgressCaptionChanged != null && myAction != action)
      {
        OnProgressCaptionChanged(myAction = action);
      }
    }
  } 

  public class SubProgressImpl : IProgressCounter
  {
    private readonly double myMax;
    private readonly IProgressTick myImpl;
    private readonly string myAction;
    private double myValue;    

    public SubProgressImpl(IProgressTick impl, double max, string action)
    {
      myImpl = impl;
      myAction = action;
      myMax = max;
    }
    
    public void Dispose()
    {
      Tick(myMax - myValue);
    }

    public double Max
    {
      get { return myMax; }
    }

    public void Tick(double size)
    {
      myValue += size;
      myImpl.Tick(size/myMax);  
    }

    public void Action(string action)
    {      
      myImpl.Action(myAction + " :: " + action);
    }

    public IProgressCounter SubProgress(string name, double units)
    {      
      return new SubProgressImpl(this, units, name);
    }
  }
}
