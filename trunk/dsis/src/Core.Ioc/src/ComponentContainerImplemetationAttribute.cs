using System;

namespace DSIS.Core.Ioc
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  public class ComponentContainerImplemetationAttribute : Attribute
  {
    public readonly Type InterfaceType;

    public ComponentContainerImplemetationAttribute(Type interfaceType)
    {
      InterfaceType = interfaceType;
    }
  }
}