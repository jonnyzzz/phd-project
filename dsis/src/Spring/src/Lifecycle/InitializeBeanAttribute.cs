using System;

namespace DSIS.Spring.Lifecycle
{
  [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
  public class InitializeBeanAttribute : Attribute
  {
  }
}
