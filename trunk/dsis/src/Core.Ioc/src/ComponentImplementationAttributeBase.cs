using System;

namespace DSIS.Core.Ioc
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  public abstract class ComponentImplementationAttributeBase : Attribute
  {
    public bool Startable { get; set; }
  }
}