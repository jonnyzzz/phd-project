using System;

namespace DSIS.Spring.Attributes
{
  [AttributeUsage(AttributeTargets.Struct|AttributeTargets.Class,AllowMultiple = true)]
  public class SpringBeanAttribute : Attribute
  {
    public string BeanName { get; set;}

    public int Priority { get; set; }
  }
}
