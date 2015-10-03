using System;
using System.Reflection;
using DSIS.Core.Ioc;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  [UsedBySpring]
  public class InputObjectConnectionPointFactory : //AbstractRegistry<IInputObjectConnectionPointFactoryExtension>,
                                              IInputObjectConnectionPointFactoryExtension
  {
    public IInputConnectionPoint Input(string name, object instance, MemberInfo member)
    {
      throw new NotImplementedException();
//      return
//        ForEach<IInputConnectionPoint>(
//          delegate(IInputObjectConnectionPointFactoryExtension factory) { return factory.Input(name, instance, member); });
    }
  }
}