using System;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Core.Ioc.JC;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Shared.Core.Ioc
{
  [JContainerPredefinedComponent, NoInheritContainer]
  public class TypeInstantiatorImpl : ITypeInstantiator
  {
    [Autowire]
    public ISubContainerFactory Container { get; set; }

    public T Instanciate<T>(params object[] instances)
    {
      if (!typeof (T).IsDefined<TypeInstanciableAttribute>())
      {
        throw new Exception(string.Format("Type {0} must be marked with {1} in order to be used for ITypeInstanciator",
                                          typeof (T).FullName, typeof (TypeInstanciableAttribute).FullName));
      }
      var c = Container.SubContainer<FakeComponent>(instances);
      c.RegisterComponentType(typeof (T));
      var cc = c.Start();
      return cc.GetComponent<T>();
    }

    private class FakeComponent : ComponentCollectionAttributeBase
    {
    }
  }
}