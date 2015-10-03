using System;
using System.Reflection;
using DSIS.Utils;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Wizard.FieldInfos
{
  [ComponentImplementation]
  public class DoubleFieldInfoFactory : FieldInfoFactoryBase<double>
  {
    protected override IFieldInfo CreateField(PropertyInfo info, object instance)
    {
      return new DoubleFieldInfo(info, instance);
    }
  }

  public class DoubleFieldInfo : StringFieldInfo
  {
    public DoubleFieldInfo(PropertyInfo property, object instance) : base(property, instance)
    {
      if (PropertyType != typeof(double))
      {
        throw new ArgumentException("Property of type double is expected but was " + property.PropertyType + " " +
                                    property);
      }
    }

    protected override void TrySetValue(string value)
    {
      double result;
      if (ParseUtil.TryParse(value, out result))
      {
        Value = result;
        return;
      }

      //Let's throw an exception if it's failed to parse double  
      Value = double.Parse(value);
    }
  }
}