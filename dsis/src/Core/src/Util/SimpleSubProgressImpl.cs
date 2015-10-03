namespace DSIS.Core.Util
{
  public class SimpleSubProgressImpl : IProgressInfo
  {
    private readonly double myWeight;
    private readonly IProgressInfo myParent;

    public SimpleSubProgressImpl(IProgressInfo parent, double weight)
    {
      myWeight = weight;
      myParent = parent;
      Maximum = 1;
    }

    public double Maximum { get; set; }
    public bool IsInterrupted
    {
      get { return myParent.IsInterrupted; }
    }

    public string Text
    {
      get { return myParent.Text; }
      set { myParent.Text = value; }
    }

    public void Tick(double step)
    {
      if (Maximum > 0)
      {
        myParent.Tick(step / Maximum * myWeight);
      }
    }

    public IProgressInfo SubProgress(double weight)
    {
      return new SimpleSubProgressImpl(this, weight);
    }

    public void Dispose()
    {
      //TODO: Check all items were ticked
    }
  }
}