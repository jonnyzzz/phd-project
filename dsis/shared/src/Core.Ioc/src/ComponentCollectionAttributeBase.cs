using System;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Shared.Core.Ioc
{
  [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
  public class ComponentCollectionAttributeBase : ComponentImplementationAttributeBase
  {
  }
}