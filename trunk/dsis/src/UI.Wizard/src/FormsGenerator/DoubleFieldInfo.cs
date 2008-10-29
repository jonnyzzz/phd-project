using System;
using System.Reflection;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class DoubleFieldInfo : StringFieldInfo
  {
    public DoubleFieldInfo(string caption, string description, PropertyInfo property, object instance) : base(caption, description, property, instance)
    {
      if (PropertyType != typeof(double))
      {
        throw new ArgumentException("Property of type double is expected but was " + property.PropertyType + " " +
                                    property);
      }
    }

    protected override void TrySetValue(string value)
    {
      Value = double.Parse(value);
    }
  }
}