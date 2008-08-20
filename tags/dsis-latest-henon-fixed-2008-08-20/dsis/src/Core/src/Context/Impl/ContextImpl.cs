using System.Collections.Generic;
using DSIS.Core.Src.Context;

namespace DSIS.Core.src.Context.Impl
{
  public class ContextImpl : IContext, IWritableContext
  {
    private Dictionary<string, object> myCollection = new Dictionary<string, object>();

    #region IContext Members

    public T GetValue<T>(ContextKey<T> key)
    {
      return GetValue(key, default(T));
    }

    public T GetValue<T>(ContextKey<T> key, T def)
    {
      object o;
      return myCollection.TryGetValue(key.Key, out o) ? (T) o : def;
    }

    #endregion

    #region IWritableContext Members

    public void Add<T>(ContextKey<T> key, T value)
    {
      myCollection[key.Key] = value;
    }

    public void Remove<T>(ContextKey<T> key)
    {
      myCollection.Remove(key.Key);
    }

    #endregion
  }
}