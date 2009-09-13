using System;

namespace EugenePetrenko.Core.FormGenerator.Api
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public class IncludeValuesProviderAttribute : Attribute
  {
    public Type[] Types { get; private set; }

    public IncludeValuesProviderAttribute(params Type[] types)
    {
      Types = types;
    }
  }
}