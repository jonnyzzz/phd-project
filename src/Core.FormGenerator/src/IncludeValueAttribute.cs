using System;

namespace EugenePetrenko.Core.FormGenerator
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
  public class IncludeValueAttribute : IncludeGenerateAttribute
  {
  }
}