using System;

namespace DSIS.Core.Ioc
{
  [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
  public abstract class ComponentInterfaceAttributeBase : Attribute
  {
  }
}