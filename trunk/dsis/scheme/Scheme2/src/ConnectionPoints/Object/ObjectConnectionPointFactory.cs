using System;
using System.Reflection;
using DSIS.Spring;
using DSIS.Spring.Util;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  [UsedBySpring]
  public class ObjectConnectionPointFactoryImpl :
    Registrar<IObjectConnectionPointFactoryExtension, ObjectConnectionPointFactory>,
    IObjectConnectionPointFactoryExtension
  {
    public ObjectConnectionPointFactoryImpl(ObjectConnectionPointFactory factory) : base(factory)
    {
    }

    public IInputConnectionPoint Input(string name, object instance, MemberInfo _property)
    {
      PropertyInfo property = _property as PropertyInfo;
      if (property == null)
        return null;

      return
        (IInputConnectionPoint)
        CreateGenericInstance(typeof (InputConnectionPoint<>), property.PropertyType,
                              new object[] {name, instance, property});
    }

    public IOutputConnectionPoint Output(string name, object instance, MemberInfo _field)
    {
      EventInfo evt = _field as EventInfo;
      if (evt == null)
        return null;

      Type del = evt.EventHandlerType;

      if (!del.IsGenericType && del.GetGenericTypeDefinition() != typeof (DataReady<>))
        return null;

      Type type = del.GetGenericArguments()[0];

      return
        (IOutputConnectionPoint)
        CreateGenericInstance(typeof (OutputConnectionPoint<>), type, new object[] {name, instance, evt});
    }

    private static object CreateGenericInstance(Type generic, Type type, object[] args)
    {
      Type tp = generic.MakeGenericType(type);
      return Activator.CreateInstance(tp, args);
    }
  }
}