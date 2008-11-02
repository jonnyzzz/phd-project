using System;
using System.Reflection;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class LongFieldInfo : StringFieldInfo
  {
    public LongFieldInfo(string caption, string description, PropertyInfo property, object instance) : base(caption, description, property, instance)
    {
      if (PropertyType != typeof(long))
      {
        throw new ArgumentException("Property of type double is expected but was " + property.PropertyType + " " +
                                    property);
      }
    }

    protected override void TrySetValue(string value)
    {
      Value = long.Parse(value);
    }
  }
}