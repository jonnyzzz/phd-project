using System;

namespace EugenePetrenko.Shared.Core.Ioc.Api
{
  /// <summary>
  /// This component is searched only inside current container. 
  /// No parent container is called to reach that component.
  /// </summary>
  [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
  public class NoInheritContainerAttribute : Attribute
  {
  }
}