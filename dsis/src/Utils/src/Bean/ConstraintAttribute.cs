using System;

namespace DSIS.Utils.Bean
{
  public abstract class ConstraintAttribute : Attribute
  {
    public delegate void DAddConstraint(string error);

    public abstract void CheckValue(object value, DAddConstraint callback);
  }
}