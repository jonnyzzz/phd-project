using System;

namespace DSIS.Scheme2.Attributed
{
  [AttributeUsage(AttributeTargets.Field|AttributeTargets.Event)]
  public class OutputAttribute : ConnectionPointAttribute
  {
    public OutputAttribute(string name) : base(name)
    {
    }
  }
}