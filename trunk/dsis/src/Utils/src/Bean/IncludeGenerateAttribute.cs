using System;

namespace DSIS.UI.Wizard.FormsGenerator
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public class IncludeGenerateAttribute : Attribute{
    public string Title { get; set; }
    public string Description { get; set; }
  }
}