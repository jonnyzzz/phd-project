using System;
using EugenePetrenko.Shared.Core.Ioc.Api;

[assembly : AssemblyWithComponents]

namespace EugenePetrenko.Shared.Core.Ioc.Api
{
  [AttributeUsage(AttributeTargets.Assembly)]
  public class AssemblyWithComponentsAttribute : Attribute
  {
  }
}