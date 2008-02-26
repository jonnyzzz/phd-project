using System;

namespace DSIS.Scheme.Attributed
{
  [AttributeUsage(AttributeTargets.Field|AttributeTargets.Property)]
  public class InputAttribute : ConnectionPointAttribute
  {
    public InputAttribute(string name) : base(name)
    {
    }
  }
}