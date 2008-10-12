using System;

namespace DSIS.Core.Ioc
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  public abstract class ComponentImplemetationAttributeBase : Attribute
  {
  }
}