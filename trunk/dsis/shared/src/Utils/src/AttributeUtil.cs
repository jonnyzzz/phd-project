using System;

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
}