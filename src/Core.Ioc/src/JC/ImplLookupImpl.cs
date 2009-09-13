using System;
using System.Collections.Generic;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Shared.Core.Ioc.JC
{
  public class ImplLookupImpl : IImplLoopup
  {
    private readonly IBaseTypesLookup myLookup;
    private readonly MultiHashDictionary<Type, Type> myTypeToImpl = new MultiHashDictionary<Type, Type>();

    public ImplLookupImpl(IBaseTypesLookup lookup)
    {
      myLookup = lookup;
    }

    public IEnumerable<Type> GetImplementations(Type y)
    {
      return new List<Type>(myTypeToImpl.GetValues(y));
    }

    public void RegisterImplementation(Type y)
    {
      foreach (var baseType in myLookup.GetBaseTypes(y))
      {
        myTypeToImpl.AddValue(baseType, y);
      }
    }
  }
}