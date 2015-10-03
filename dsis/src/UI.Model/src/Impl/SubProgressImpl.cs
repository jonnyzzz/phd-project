namespace DSIS.UI.Model.Impl
{
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