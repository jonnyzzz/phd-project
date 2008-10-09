using System;

namespace DSIS.Core.Ioc
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  public class ComponentImplemetationAttribute : ComponentImplemetationAttributeBase 
  {
    public ComponentImplemetationAttribute(Type interfaceType) : base(interfaceType)
    {
    }
  }
}