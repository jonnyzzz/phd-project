using System;
using System.Reflection;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Wizard.FieldInfos
{
  [ComponentImplementation]
  public class IntFieldInfoFactory : FieldInfoFactoryBase<int>
  {
    protected override IFieldInfo CreateField(PropertyInfo info, object instance)
    {
      return new IntFieldInfo(info, instance);
    }
  }

  public class IntFieldInfo : StringFieldInfo
  {
    public IntFieldInfo(PropertyInfo property, object instance) : base(property, instance)
    {
      if (PropertyType != typeof(int))
      {
        throw new ArgumentException("Property of type double is expected but was " + property.PropertyType + " " +
                                    property);
      }
    }

    protected override void TrySetValue(string value)
    {
      Value = int.Parse(value);
    }
  }
}