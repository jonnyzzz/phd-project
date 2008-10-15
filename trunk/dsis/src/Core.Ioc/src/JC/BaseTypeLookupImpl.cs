using System;
using System.Collections.Generic;
using DSIS.Utils;

namespace DSIS.Core.Ioc.JC
{
  public class BaseTypeLookupImpl : IBaseTypesLookup
  {
    private readonly ITypesFilter myFilter;
    private readonly MultiHashDictionary<Type, Type> myTypeToBasesCache = new MultiHashDictionary<Type, Type>();

    public BaseTypeLookupImpl(ITypesFilter filter)
    {
      myFilter = filter;
    }

    public IEnumerable<Type> GetBaseTypes(Type y)
    {
      if (!myFilter.Accept(y))
        return EmptyArray<Type>.Instance;

      if (myTypeToBasesCache.ContainsKey(y))
        return myTypeToBasesCache.GetValues(y);

      var result = new HashSet<Type> {y};
      var baseType = y.BaseType;
      if (baseType != null)
      {
        result.UnionWith(GetBaseTypes(baseType));
      }
      foreach (var type in y.GetInterfaces())
      {
        result.UnionWith(GetBaseTypes(type));
      }
      
      myTypeToBasesCache.AddValues(y, result);

      return result;
    }
  }
}