using System;

namespace EugenePetrenko.Shared.Core.Ioc.Api
{
  /// <summary>
  /// Marker attribute for types that can be instanciated using
  /// <see cref="ITypeInstantiator"/> intefrace
  /// </summary>
  [AttributeUsage(AttributeTargets.Class)]
  public class TypeInstanciableAttribute : Attribute
  {
  }
}