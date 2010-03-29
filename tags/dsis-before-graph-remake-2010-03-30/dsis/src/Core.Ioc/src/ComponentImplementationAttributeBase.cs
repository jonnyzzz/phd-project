using System;
using JetBrains.Annotations;

namespace DSIS.Core.Ioc
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  [MeansImplicitUse]
  public abstract class ComponentImplementationAttributeBase : Attribute
  {
    public bool Startable { get; set; }
  }
}