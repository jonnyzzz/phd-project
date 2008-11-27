using System;
using System.Reflection;
using DSIS.Spring;
using DSIS.Spring.Util;
using DSIS.Utils;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  [UsedBySpring]
  public class PropertyInputObjectConnectionPointFactoryImpl :
    Registrar<IInputObjectConnectionPointFactoryExtension, InputObjectConnectionPointFactory>,
    IInputObjectConnectionPointFactoryExtension
  {
    public PropertyInputObjectConnectionPointFactoryImpl(InputObjectConnectionPointFactory factory) : base(factory)
    {
    }

    public IInputConnectionPoint Input(string name, object instance, MemberInfo _property)
    {
      PropertyInfo property = _property as PropertyInfo;
      if (property != null)
      {
        return
          (IInputConnectionPoint)
          GenericHelper.CreateGenericInstance(typeof (PropertyInputConnectionPoint<>), new Type[]{property.PropertyType},
                                new object[] {name, instance, property});
      }
      return null;
    }
  }
}