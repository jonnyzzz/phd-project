using System;
using System.Reflection;

namespace DSIS.Utils
{
  public static class AttributeUtil
  {
    public static Q OneInstance<Q>(this ICustomAttributeProvider obj)
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