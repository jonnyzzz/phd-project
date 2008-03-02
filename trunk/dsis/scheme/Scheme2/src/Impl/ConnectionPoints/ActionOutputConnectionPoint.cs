using System;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Impl.ConnectionPoints
{
  public class ActionOutputConnectionPoint<T> : OutputConnectionPointBase<T>, IInitializeAware
  {
    private readonly T myValue;

    public ActionOutputConnectionPoint(string name, T value) : base(name)
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

  public static class ActionOutputConnectionPoint {

    public static IOutputConnectionPoint FromActionObject(string name, object o)
    {
      Type type = o.GetType();
      return (IOutputConnectionPoint) Activator.CreateInstance(typeof (ActionOutputConnectionPoint<>).MakeGenericType(type), name, o);
    }
  }
}