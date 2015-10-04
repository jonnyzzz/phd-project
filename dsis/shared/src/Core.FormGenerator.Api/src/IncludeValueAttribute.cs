using System;

namespace EugenePetrenko.Core.FormGenerator.Api
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
  public class IncludeValueAttribute : IncludeGenerateAttribute
  {
  }
}