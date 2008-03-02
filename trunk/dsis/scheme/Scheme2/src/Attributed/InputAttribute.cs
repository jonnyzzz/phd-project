using System;

namespace DSIS.Scheme2.Attributed
{
  [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
  public class InputAttribute : ConnectionPointAttribute
  {
    public InputAttribute(string name) : base(name)
    {
    }
  }
}