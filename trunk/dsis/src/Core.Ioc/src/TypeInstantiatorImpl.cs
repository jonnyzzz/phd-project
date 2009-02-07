using System;
using DSIS.Core.Ioc.JC;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  [JContainerPredefinedComponent, NoInheritContainer]
  public class TypeInstantiatorImpl : ITypeInstantiator
  {
    [Autowire]
    public ISubContainerFactory Container { get; set; }

    public T Instanciate<T>(params object[] instances)
    {
      if (!typeof(T).IsDefined<TypeInstanciableAttribute>())
      {
        throw new Exception(string.Format("Type {0} must be marked with {1} in order to be used for ITypeInstanciator",
                                          typeof (T).FullName, typeof (TypeInstanciableAttribute).FullName));
      }
      var c = Container.SubContainer<FakeComponent>();
      c.RegisterComponentType(typeof(T));
      instances.Each(c.RegisterComponent);
      return c.GetComponent<T>();
    }

    private class FakeComponent : ComponentCollectionAttributeBase {}
  }
}