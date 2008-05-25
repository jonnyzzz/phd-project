using System;
using System.Reflection;

namespace DSIS.Utils
{
  public class AttributeUtil<T>
  {
    protected static TA GetAttributeInstance<TA>() where TA : Attribute
    {
      Type type = typeof (T);
      object[] os = type.GetCustomAttributes(typeof (TA), true);
      return os.Length > 0 ? (TA) os[0] : default(TA);
    }
  }

  public static class AttributeUtil
  {
    public static Q OneInstance<Q>(this ICustomAttributeProvider obj)
      where Q : Attribute
    {
      object[] o = obj.GetCustomAttributes(typeof (Q), true);
      if (o.Length > 1)
        throw new ArgumentException("More that one object");
      else if (o.Length == 1)
        return (Q) (o[0]);
      else return default(Q);
    }
  }
}