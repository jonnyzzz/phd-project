using System;

namespace DSIS.Scheme.Attributed
{
  [AttributeUsage(AttributeTargets.Field|AttributeTargets.Property)]
  public class OutputAttribute : ConnectionPointAttribute
  {
    public OutputAttribute(string name) : base(name)
    {
    }
  }

  public interface IField
  {
    object Value {get; set;}
  }

  public interface IDataNode
  {
    
  }
}