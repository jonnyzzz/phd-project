using System;
using JetBrains.Annotations;

namespace EugenePetrenko.Shared.Core.Ioc.Api
{
  /// <summary>
  /// Marker attribute for types that can be instanciated using
  /// <see cref="ITypeInstantiator"/> intefrace
  /// </summary>
  [AttributeUsage(AttributeTargets.Class)]
  [MeansImplicitUse]
  public class TypeInstanciableAttribute : Attribute
  {
  }
}