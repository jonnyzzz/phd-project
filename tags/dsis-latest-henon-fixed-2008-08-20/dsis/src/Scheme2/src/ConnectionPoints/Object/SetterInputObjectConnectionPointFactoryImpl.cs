using System;
using System.Reflection;
using DSIS.Spring;
using DSIS.Spring.Util;
using DSIS.Utils;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  [UsedBySpring]
  public class SetterInputObjectConnectionPointFactoryImpl :
    Registrar<IInputObjectConnectionPointFactoryExtension, InputObjectConnectionPointFactory>,
    IInputObjectConnectionPointFactoryExtension
  {
    public SetterInputObjectConnectionPointFactoryImpl(InputObjectConnectionPointFactory factory)
      : base(factory)
    {
    }

    public IInputConnectionPoint Input(string name, object instance, MemberInfo _property)
    {
      MethodInfo method = _property as MethodInfo;
      if (method != null && method.GetParameters().Length == 1)
      {
        return
          (IInputConnectionPoint)
          GenericHelper.CreateGenericInstance(typeof(SetterInputConnectionPoint<>), new Type[] { method.GetParameters()[0].ParameterType },
                                new object[] { name, instance, method });

      }

      return null;
    }
  }
}