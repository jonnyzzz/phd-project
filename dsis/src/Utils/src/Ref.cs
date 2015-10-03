using System;

namespace DSIS.Utils
{
  public class Ref<T>
  {
    private readonly T myValue;
    private readonly bool myHasValue;

    public Ref(T value) : this(value, true)
    {
    }

    public Ref() : this(default(T), false)
    {
    }

    private Ref(T value, bool hasValue)
    {
      myValue = value;
      myHasValue = hasValue;
    }

    public T Value
    {
      get
      {
        if (!HasValue)
        {
          throw new ArgumentException("No value is defined");
        }
        return myValue;
      }
    }

    public bool HasValue
    {
      get { return myHasValue; }
    }
  }

  public static class Ref
  {
    public static Ref<T> ToRef<T>(this T obj)
    {
      return new Ref<T>(obj);
    }

    public static Ref<T> Null<T>()
    {
      return new Ref<T>();
    }
    
  }
}