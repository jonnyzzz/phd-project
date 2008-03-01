using System.Reflection;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Impl.ConnectionPoints
{
  /// <summary>
  /// Bound object produces new data using event
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class OutputConnectionPoint<T> : IOutputConnectionPoint<T>
  {
    private readonly object myInstance;
    private readonly EventInfo myEvent;
    private readonly string myName;

    public OutputConnectionPoint(string name, object instance, EventInfo @event)
    {
      myInstance = instance;
      myEvent = @event;
      myName = name;
    }

    public event DataReady<T> OnDataReady
    {
      add { myEvent.AddEventHandler(myInstance, value); }
      remove { myEvent.RemoveEventHandler(myInstance, value); }
    }

    public void With(IOutputConnectionPointWith with)
    {
      with.Register(this);
    }

    public void Bind(IInputConnectionPoint pt)
    {
      pt.With(new BindInput<T>(this));
    }

    public string Name
    {
      get { return myName; }
    }
  }
}