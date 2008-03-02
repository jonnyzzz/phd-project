using System;
using DSIS.Scheme2.ConnectionPoints.Xml.Output;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  public class ObjectOutputConnectionPoint<T> : OutputConnectionPointBase<T>, IInitializeAware
  {
    private readonly T myValue;

    public ObjectOutputConnectionPoint(string name, T value) : base(name)
    {
      myValue = value;
    }

    public override event DataReady<T> OnDataReady;

    public void Initialized()
    {
      if (OnDataReady != null)
      {
        OnDataReady(myValue);
      }
    }
  }

  public static class ActionOutputConnectionPoint
  {
    public static IOutputConnectionPoint FromActionObject(string name, object o)
    {
      Type type = o.GetType();
      return
        (IOutputConnectionPoint)
        Activator.CreateInstance(typeof (ObjectOutputConnectionPoint<>).MakeGenericType(type), name, o);
    }
  }
}