using System;
using System.Reflection;
using DSIS.Core.Ioc;
using DSIS.Utils;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  [UsedBySpring]
  public class OutputObjectConnectionPointFactoryImpl :
//    Registrar<IOutputObjectConnectionPointFactoryExtension, OutputObjectConnectionPointFactory>,
    IOutputObjectConnectionPointFactoryExtension
  {
    public OutputObjectConnectionPointFactoryImpl(OutputObjectConnectionPointFactory factory)
    {
    }

    public IOutputConnectionPoint Output(string name, object instance, MemberInfo _field)
    {
      EventInfo evt = _field as EventInfo;
      if (evt == null)
        return null;

      Type del = evt.EventHandlerType;

      if (!del.IsGenericType && del.GetGenericTypeDefinition() != typeof(DataReady<>))
        return null;

      Type type = del.GetGenericArguments()[0];

      return
        (IOutputConnectionPoint)
        GenericHelper.CreateGenericInstance(typeof(OutputConnectionPoint<>), new[] { type }, new[] { name, instance, evt });
    }
  }
}