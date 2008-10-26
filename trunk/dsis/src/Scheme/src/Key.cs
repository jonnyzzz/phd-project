using System;
using System.Collections;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme
{
  public interface IKey
  {
    string Name { get; }

    string ShortName { get; }

    void Copy(IReadOnlyContext from, IWriteOnlyContext to);
    bool EqualsWithoutName(IKey key);

    IEqualityComparer Comparer { get; }
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

    public IEqualityComparer Comparer
    {
      get { return EqualityComparerFactory<TValue>.GetOldComparer(); }
    }


    public override int GetHashCode()
    {
      return myName.GetHashCode();
    }

    public TValue Get(IReadOnlyContext ctx)
    {
      return ctx.Get(this);
    }

    public void Set(IWriteOnlyContext ctx, TValue value)
    {
      ctx.Set(this, value);
    }

    public void Remove(Context ctx)
    {
      ctx.Remove(this);
    }

    public void Copy(IReadOnlyContext input, IWriteOnlyContext output)
    {
      Set(output, Get(input));
    }
  }
}