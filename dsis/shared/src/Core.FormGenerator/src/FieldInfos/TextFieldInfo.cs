using System;
using System.Reflection;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  public class TextFieldInfo : StringFieldInfo
  {
    public TextFieldInfo(PropertyInfo property, object instance) : base(property, instance)
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