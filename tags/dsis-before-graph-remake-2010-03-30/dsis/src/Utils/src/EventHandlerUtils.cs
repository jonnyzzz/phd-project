using System;

namespace DSIS.Utils
{
  public static class EventHandlerUtils
  {
    public static void Fire<T>(this EventHandler<T> hander, object instance, T data) 
      where T : EventArgs
    {
      if (hander != null)
      {
        hander(instance, data);
      }
    }
  }
}