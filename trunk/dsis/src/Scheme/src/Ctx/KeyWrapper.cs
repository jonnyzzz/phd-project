using System;

namespace DSIS.Scheme.Ctx
{
  internal abstract class KeyWrapper : IEquatable<KeyWrapper>
  {
    protected abstract string Key { get; }
    protected abstract Type Type { get; }

    public bool Equals(KeyWrapper other)
    {
      return Equals(Key, other.Key) && Equals(Type, other.Type);
    }

    public override int GetHashCode()
    {
      return Key.GetHashCode() + 31* Type.GetHashCode();
    }

    public override string ToString()
    {
      return "KeyWrapper:";
    }

    public static KeyWrapper FromKey<Y>(Key<Y> key)
    {
      return new KeyWrapperImpl<Y>(key);
    }

    public abstract bool IsKey<Y>();

    public override bool Equals(object obj)
    {
      var w = obj as KeyWrapper;
      return w != null && w.Equals(this);
    }

    public abstract Key<Y> Cast<Y>();

    public abstract bool EqualsKey(IKey key);

    private class KeyWrapperImpl<T> : KeyWrapper
    {
      private readonly Key<T> myKey;

      public KeyWrapperImpl(Key<T> key)
      {
        myKey = key;
      }

      protected override string Key
      {
        get { return myKey.Name; }
      }

      protected override Type Type
      {
        get { return typeof (T); }
      }

      public override string ToString()
      {
        return base.ToString() + myKey;
      }

      public override bool IsKey<Y>()
      {
        return new Key<Y>("QQQ").EqualsWithoutName(myKey);
      }

      public override Key<Y> Cast<Y>()
      {
        //todo: Check that case
        return (Key<Y>)(object)myKey;
      }

      public override bool EqualsKey(IKey key)
      {
        return myKey.Equals(key);
      }
    }
  }
}