using System.Reflection;
using DSIS.Spring;
using DSIS.Spring.Util;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  [UsedBySpring]
  public class ObjectConnectionPointFactory : AbstractRegistry<IObjectConnectionPointFactoryExtension>,
                                              IObjectConnectionPointFactoryExtension
  {
    public IInputConnectionPoint Input(string name, object instance, MemberInfo member)
    {
      return
        ForEach<IInputConnectionPoint>(
          delegate(IObjectConnectionPointFactoryExtension factory) { return factory.Input(name, instance, member); });
    }

    public IOutputConnectionPoint Output(string name, object instance, MemberInfo member)
    {
      return
        ForEach<IOutputConnectionPoint>(
          delegate(IObjectConnectionPointFactoryExtension factory) { return factory.Output(name, instance, member); });
    }
  }
}