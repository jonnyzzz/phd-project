using System;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  public abstract class ComponentImplemetationAttributeBase : Attribute
  {
    [Used]
    public readonly Type InterfaceType;

    protected ComponentImplemetationAttributeBase(Type interfaceType)
    {
      InterfaceType = interfaceType;
    }
  }
}