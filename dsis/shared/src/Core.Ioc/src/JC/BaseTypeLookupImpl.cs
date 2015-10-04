using System;
using System.Collections.Generic;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Shared.Core.Ioc.JC
{
  public class BaseTypeLookupImpl : IBaseTypesLookup
  {
    private readonly ITypesFilter myFilter;
    private readonly MultiHashDictionary<Type, Type> myTypeToBasesTypesCache = new MultiHashDictionary<Type, Type>();
    private readonly MultiHashDictionary<Type, Type> myTypeToBasesClassesCache = new MultiHashDictionary<Type, Type>();

    public BaseTypeLookupImpl(ITypesFilter filter)
    {
      myFilter = filter;
    }

    public IEnumerable<Type> GetBaseTypes(Type y)
    {
      return GetBases(myTypeToBasesTypesCache, y, true);
    }

    public IEnumerable<Type> GetBaseClasses(Type y)
    {
      return GetBases(myTypeToBasesClassesCache, y, false);
    }

    private IEnumerable<Type> GetBases(MultiHashDictionary<Type, Type> cache, Type y, bool includeInterfaces)
    {
      if (!myFilter.Accept(y))
        return EmptyArray<Type>.Instance;

      if (cache.ContainsKey(y))
        return cache.GetValues(y);

      var result = new HashSet<Type> {y};
      var baseType = y.BaseType;
      if (baseType != null)
      {
        result.UnionWith(GetBases(cache, baseType, includeInterfaces));
      }
      if (includeInterfaces)
      {
        foreach (var type in y.GetInterfaces())
        {
          result.UnionWith(GetBases(cache, type, true));
        }
      }

      cache.AddValues(y, result);

      return result;
    }
  }
}