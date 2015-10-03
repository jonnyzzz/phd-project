using System;
using System.Reflection;
using DSIS.Core.Ioc;

namespace DSIS.UI.Wizard.FieldInfos
{
  [ComponentImplementation]
  public class TextFieldInfoFactory : FieldInfoFactoryBase<string>
  {
    protected override IFieldInfo CreateField(PropertyInfo info, object instance)
    {
      return new TextFieldInfo(info, instance);
    }
  }

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