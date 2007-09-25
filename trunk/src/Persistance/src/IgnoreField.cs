using System;

namespace DSIS.Persistance
{
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
  public class IgnoreField: Attribute
  {   
  }
}