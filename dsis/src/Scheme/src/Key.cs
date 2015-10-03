using System;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme
{
  public interface IKey
  {
    string Name { get; }

    string ShortName { get; }

    void Copy(Context from, Context to);
    bool EqualsWithoutName(IKey key);
  }

  public class Key<TValue> : IKey, IEquatable<Key<TValue>>
  {
    private readonly string myName;

    public Key(string name)
    {
      myName = name;
    }

    public string Name
    {
      get { return myName + "|" + typeof(TValue).FullName; }
    }

    public string ShortName
    {
      get { return myName; }
    }

    public override string ToString()
    {
      return "Key:" + Name;
    }

    public bool Equals(Key<TValue> key)
    {
      if (key == null) return false;

      return Equals(myName, key.myName);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(this, obj)) return true;
      return Equals(obj as Key<TValue>);
    }

    public bool EqualsWithoutName(IKey key)
    {
      return key is Key<TValue>;      
    }


    public override int GetHashCode()
    {
      return myName.GetHashCode();
    }

    public TValue Get(Context ctx)
    {
      return ctx.Get(this);
    }

    public void Set(Context ctx, TValue value)
    {
      ctx.Set(this, value);
    }

    public void Remove(Context ctx)
    {
      ctx.Remove(this);
    }

    public void Copy(Context input, Context output)
    {
      Set(output, Get(input));
    }
  }
}