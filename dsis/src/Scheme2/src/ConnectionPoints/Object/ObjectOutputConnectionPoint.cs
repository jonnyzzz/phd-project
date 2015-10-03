using System;
using System.Collections.Generic;
using DSIS.Scheme2.ConnectionPoints.Xml.Output;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  public class ObjectOutputConnectionPoint<T> : OutputConnectionPointBase<T>, IInitializeAware
  {
    private readonly T[] myValue;

    public ObjectOutputConnectionPoint(string name, T[] value) : base(name)
    {
      myValue = value;
    }

    public override event DataReady<T> OnDataReady;

    public void Initialized()
    {
      if (OnDataReady != null)
      {
        foreach (T t in myValue)
        {
          OnDataReady(t);
        }        
      }
    }
  }

  public class ActionOutputConnectionPoint
  {
    private static IEnumerable<Type> Bases(Type type)
    {
      while (type != null)
      {
        yield return type;
        type = type.BaseType;
      }
    }

    protected static Type InferCommonType(IEnumerable<object> os)
    {
      IEnumerator<object> enu = os.GetEnumerator();
      enu.MoveNext();
      Type type = enu.Current.GetType();

      while (enu.MoveNext())
      {
        Type next = enu.Current.GetType();

        if (type == typeof(object))
          return type;
        if (next == typeof(object))
          return next;
        
        if (type != next)
        {
          List<Type> tBases = new List<Type>(Bases(type));
          List<Type> nBases = new List<Type>(Bases(next));

          tBases.Reverse();
          nBases.Reverse();

          int i;
          for (i = 0; i < Math.Min(tBases.Count, nBases.Count); i++)
          {
            if (tBases[i] != nBases[i])
              break;
          }
          type = tBases[i - 1];          
        }        
      }
      return type;
    }

    public static IOutputConnectionPoint FromActionObject(string name, object[] o)
    {
      if (o.Length == 0)
        return null;
      
      Type type = InferCommonType(o);
      Array arr = Array.CreateInstance(type, o.Length);
      for (int i = 0; i < o.Length; i++)
        arr.SetValue(o[i], i);

      return
          (IOutputConnectionPoint)
          Activator.CreateInstance(typeof(ObjectOutputConnectionPoint<>).MakeGenericType(type), name, arr);
    }
  }
}