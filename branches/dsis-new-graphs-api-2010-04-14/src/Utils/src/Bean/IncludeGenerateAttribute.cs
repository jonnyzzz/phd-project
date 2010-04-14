using System;
using System.Drawing;
using JetBrains.Annotations;

namespace DSIS.Utils.Bean
{
  [MeansImplicitUse]
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public class IncludeGenerateAttribute : Attribute{
    public string Title { get; set; }
    public string Description { get; set; }
  }

  [MeansImplicitUse]
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public abstract class EditorPreferenceAttribute : Attribute
  {
  }

  public class TextAreaEditorPreference : EditorPreferenceAttribute
  {
    public int EnsureLines { get; set; }

    public Font Font { get; set; }

    public TextAreaEditorPreference()
    {
      EnsureLines = 20;
    }
  }

  [MeansImplicitUse]
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
  public class IncludeValueAttribute : IncludeGenerateAttribute
  {
  }

  [MeansImplicitUse]
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