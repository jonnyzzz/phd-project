using System;

namespace DSIS.Core.Ioc
{
  [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
  public class ComponentCollectionAttributeBase : ComponentImplementationAttributeBase
  {
  }
}