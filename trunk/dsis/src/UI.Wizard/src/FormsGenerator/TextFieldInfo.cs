using System;
using System.Reflection;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class TextFieldInfo : StringFieldInfo
  {
    public TextFieldInfo(string caption, string description, PropertyInfo property, object instance) : base(caption, description, property, instance)
    {
      if (PropertyType != typeof(string))
      {
        throw new ArgumentException("Property of type double is expected but was " + property.PropertyType + " " +
                                    property);
      }
    }

    protected override void TrySetValue(string value)
    {
      Value = value;
    }
  }
}