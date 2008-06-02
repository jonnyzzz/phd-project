using System;

namespace DSIS.Utils.Bean
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public class IncludeGenerateAttribute : Attribute{
    public string Title { get; set; }
    public string Description { get; set; }
  }

  public abstract class ConstraintAttribute : Attribute
  {
    public delegate void DAddConstraint(string error);

    public abstract void CheckValue(object value, DAddConstraint callback);
  }

  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public class GreatherThanZeroAttribute : ConstraintAttribute
  {
    private static bool Check(object o)
    {
      if (o is int)
      {
        return ((int) o) > 0;
      }

      if (o is long)
      {
        return ((long) o) > 0;
      }

      if (o is double)
      {
        return ((double) o) > 0;
      }

      throw new ArgumentException("Type " + o.GetType().AssemblyQualifiedName + " is not supported");
    }

    public override void CheckValue(object value, DAddConstraint callback)
    {
      if (!Check(value))
      {
        callback("Value should be greather than zero");
      }
    }
  }
}