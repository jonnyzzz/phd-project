using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  public class ComponentInterfaceLookupImpl : IComponentInterfaceLookup    
  {
    private readonly ITypesFilter myFiler;

    public ComponentInterfaceLookupImpl(ITypesFilter filer)
    {
      myFiler = filer;
    }

    public IEnumerable<Type> FindInterfaces<T>(Type type) where T : Attribute
    {
      var set = new HashSet<Type>();
      CollectAllTypes(type, set);
      return set.Filter(x => x.IsDefined(typeof(T), false));
    }

    private void CollectAllTypes(Type type, HashSet<Type> bases)
    {
      if (type == null || !myFiler.Accept(type) || bases.Contains(type))
        return;

      bases.Add(type);

      var baseType = type.BaseType;
      if (baseType != null)
      {
        CollectAllTypes(baseType, bases);
      }

      foreach (var interf in type.GetInterfaces())
      {
        CollectAllTypes(interf, bases);
      }
    }
  }
}