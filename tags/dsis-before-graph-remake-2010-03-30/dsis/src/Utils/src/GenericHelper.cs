using System;

namespace DSIS.Utils
{
  public static class GenericHelper
  {
    public static object CreateGenericInstance(Type generic, Type[] type, object[] args)
    {
      Type tp = generic.MakeGenericType(type);
      return Activator.CreateInstance(tp, args);
    }
  }
}