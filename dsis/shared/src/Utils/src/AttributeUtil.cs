using System;
using System.Reflection;

namespace EugenePetrenko.Shared.Utils
{
  public static class AttributeUtil
  {
    public static bool IsDefined<T>(this ICustomAttributeProvider obj)
      where T : Attribute
    {
      return obj.IsDefined(typeof (T), true);
    }

    public static Q GetCustomAttribute<Q>(this ICustomAttributeProvider obj)
      where Q : Attribute
    {
      object[] o = obj.GetCustomAttributes(typeof (Q), true);
      if (o.Length > 1)
        throw new ArgumentException("More that one object");
      if (o.Length == 1)
        return (Q) (o[0]);
      return default(Q);
    }
  }
}