using System.Reflection;
using DSIS.Scheme2.ConnectionPoints.Xml.Output;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  /// <summary>
  /// Bound object produces new data using event
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class OutputConnectionPoint<T> : OutputConnectionPointBase<T>
  {
    private readonly object myInstance;
    private readonly EventInfo myEvent;

    public OutputConnectionPoint(string name, object instance, EventInfo @event) : base(name)
    {
      myInstance = instance;
      myEvent = @event;
    }

    public override event DataReady<T> OnDataReady
    {
      add { myEvent.AddEventHandler(myInstance, value); }
      remove { myEvent.RemoveEventHandler(myInstance, value); }
    }
  }
}