using System;
using System.Reflection;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  [ComponentImplementation]
  public class LongFieldInfoFactory : FieldInfoFactoryBase<long>
  {
    protected override IFieldInfo CreateField(PropertyInfo info, object instance)
    {
      return new LongFieldInfo(info, instance);
    }
  }

  public class LongFieldInfo : StringFieldInfo
  {
    public LongFieldInfo(PropertyInfo property, object instance) : base(property, instance)
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