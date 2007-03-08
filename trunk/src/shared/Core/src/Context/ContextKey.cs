using System;
using DSIS.Core.System;

namespace DSIS.Core.Src.Context
{
  public abstract class ContextKey<T>
  {
    private string myKey;

    internal ContextKey(string key)
    {
      myKey = key + "|" + TypeName(typeof (T));
    }

    protected static string TypeName(Type t)
    {
      return typeof (T).AssemblyQualifiedName + "||" + typeof (T).FullName;
    }

    public override bool Equals(object obj)
    {
      if (this == obj) return true;
      ContextKey<T> contextKey = obj as ContextKey<T>;
      if (contextKey == null) return false;
      return Equals(myKey, contextKey.myKey);
    }

    public override int GetHashCode()
    {
      return myKey.GetHashCode();
    }

    internal string Key
    {
      get { return myKey; }
    }
  }

  internal class PredefinedObject<T> : ContextKey<T>
  {
    public PredefinedObject() : base("System:Predefined:")
    {
    }
  }

  public static class PredefinedObjects
  {
    public static readonly ContextKey<ISystemInfo> SYSTEM_INFO = new PredefinedObject<ISystemInfo>();
  }
}