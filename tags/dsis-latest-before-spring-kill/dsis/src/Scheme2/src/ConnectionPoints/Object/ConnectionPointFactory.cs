using System.Reflection;
using DSIS.Spring;
using DSIS.Spring.Util;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  [UsedBySpring]
  public class InputObjectConnectionPointFactory : AbstractRegistry<IInputObjectConnectionPointFactoryExtension>,
                                              IInputObjectConnectionPointFactoryExtension
  {
    public IInputConnectionPoint Input(string name, object instance, MemberInfo member)
    {
      return
        ForEach<IInputConnectionPoint>(
          delegate(IInputObjectConnectionPointFactoryExtension factory) { return factory.Input(name, instance, member); });
    }
  }
}