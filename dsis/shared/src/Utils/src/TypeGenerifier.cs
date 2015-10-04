using System;
using System.Collections.Generic;
using System.Reflection;

namespace EugenePetrenko.Shared.Utils
{
  public static class TypeGenerifier
  {
    private static readonly Dictionary<Type, CallbackCaller> ourCache = new Dictionary<Type, CallbackCaller>();

    public static void CallbackType(Type t, Callback callback)
    {
      GetCaller(t).Call(callback);
    }

    public static void CallbackType<P>(Type t, Callback<P> callback, P p)
    {
      GetCaller(t).Call(callback, p);
    }

    public static R CallbackFun<P,R>(Type t, Fun<P,R> callback, P p)
    {
      return GetCaller(t).Call(callback, p);
    }

    private static CallbackCaller GetCaller(Type t)
    {
      lock (ourCache)
      {
        CallbackCaller caller;
        if (ourCache.TryGetValue(t, out caller))
        {
          return caller;
        }
    
        var info = typeof (TypeGenerifier).GetMethod("CreateCaller", BindingFlags.Static | BindingFlags.NonPublic);
        var mi = info.MakeGenericMethod(new[] {t});
        return ourCache[t] = (CallbackCaller) mi.Invoke(null, new object[0]);       
      }
    }

    [Used]
    private static CallbackCaller CreateCaller<T>()
    {
      return new CallbackHolder<T>();
    }

    public interface Callback
    {
      void Callback<T>();
    }

    public interface Callback<P>
    {
      void Callback<T>(P p);
    }

    public interface Fun<P,R>
    {
      R Callback<T>(P p);
    }

    private interface CallbackCaller
    {
      void Call(Callback cb);
      void Call<P>(Callback<P> cb, P p);
      R Call<P,R>(Fun<P,R> cb, P p);
    }

    private class CallbackHolder<T> : CallbackCaller
    {
      public void Call(Callback cb)
      {
        cb.Callback<T>();
      }

      public void Call<P>(Callback<P> cb, P p)
      {
        cb.Callback<T>(p);
      }

      public R Call<P, R>(Fun<P, R> cb, P p)
      {
        return cb.Callback<T>(p);
      }
    }
  }
}