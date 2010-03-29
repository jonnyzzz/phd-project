using System;
using JetBrains.Annotations;

namespace DSIS.Core.Ioc
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true), MeansImplicitUse]
  public class AutowireAttribute : Attribute
  {    
  }
}