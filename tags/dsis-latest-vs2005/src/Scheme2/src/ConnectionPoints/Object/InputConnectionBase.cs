using DSIS.Scheme2.ConnectionPoints;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  public abstract class InputConnectionBase<T> : IInputConnectionPoint<T>
  {
    protected readonly object myObject;
    private readonly string myName;

    protected InputConnectionBase(object @object, string name)
    {
      myObject = @object;
      myName = name;
    }

    public abstract void DataReady(T obj);

    public void With(IInputConnectionPointWith with)
    {
      with.Register(this);
    }

    public void Bind(IOutputConnectionPoint pt)
    {
      pt.With(new BindOutput<T>(this));
    }

    public string Name
    {
      get { return myName; }
    }
  }
}