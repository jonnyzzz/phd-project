using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Impl.ConnectionPoints
{
  public abstract class OutputConnectionPointBase<T> : IOutputConnectionPoint<T>
  {
    private readonly string myName;

    protected OutputConnectionPointBase(string name)
    {
      myName = name;
    }

    public string Name
    {
      get { return myName; }
    }

    public void With(IOutputConnectionPointWith with)
    {
      with.Register(this);
    }

    public void Bind(IInputConnectionPoint pt)
    {
      pt.With(new BindInput<T>(this));
    }

    public abstract event DataReady<T> OnDataReady;
  }
}