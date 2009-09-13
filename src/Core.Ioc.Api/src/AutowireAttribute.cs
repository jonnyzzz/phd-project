using System;

namespace EugenePetrenko.Shared.Core.Ioc.Api
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
  public class AutowireAttribute : Attribute
  {
  }
}