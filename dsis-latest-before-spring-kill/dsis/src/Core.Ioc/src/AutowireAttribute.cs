using System;

namespace DSIS.Core.Ioc
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public class AutowireAttribute : Attribute
  {    
  }
}