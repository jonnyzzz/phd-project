using System;
using JetBrains.Annotations;

namespace EugenePetrenko.Shared.Core.Ioc.Api
{
  [MeansImplicitUse] 
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public class AutowireAttribute : Attribute
  {
  }
}