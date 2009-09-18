using System;

namespace EugenePetrenko.Shared.Utils
{
  public static class TypeGenerifier
  {
    public static void CallbackType(Type t, Callback callback)
    {
      var mi = callback.GetType().GetMethod("Callback").MakeGenericMethod(new[] {t});
      mi.Invoke(callback, new object[0]);
    }

    public interface Callback
    {
      [Used]
      void Callback<T>();
    }
  }
}