using System;

namespace DSIS.Utils.Bean
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public class IncludeGenerateAttribute : Attribute{
    public string Title { get; set; }
    public string Description { get; set; }
  }

  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
  public class IncludeValueAttribute : IncludeGenerateAttribute
  {
  }

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