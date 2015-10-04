using System;

namespace EugenePetrenko.Shared.Core.Ioc.Api
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  public abstract class ComponentImplementationAttributeBase : Attribute
  {
    public bool Startable { get; set; }
  }
}