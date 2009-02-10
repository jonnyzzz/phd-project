using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  public class AssemblyScanerImpl : IAssemblyScaner
  {
    private readonly ITypesFilter myFiler;
    private readonly Dictionary<Assembly, HashSet<Type>> myTypesCache = new Dictionary<Assembly, HashSet<Type>>();

    public AssemblyScanerImpl(ITypesFilter filer)
    {
      myFiler = filer;
    }

    public IEnumerable<Pair<Type, T>> LoadTypes<T>(Assembly a) where T : Attribute
    {
      var list = GetAllTypes(a);

      var result = new List<Pair<Type, T>>();
      foreach (var type in list)
      {
        var attrs = type.GetCustomAttributes(typeof(T), true);
        if (attrs.Length > 0)
          result.Add(Pair.Create(type, (T)attrs[0]));
      }
      return result;  
    }

    private HashSet<Type> GetAllTypes(Assembly a)
    {
      if (!myFiler.Accept(a))
        return new HashSet<Type>();
      
      HashSet<Type> types;
      if (myTypesCache.TryGetValue(a, out types))
        return types;

      return myTypesCache[a] = new HashSet<Type>(a.GetTypes());
    }
  }
}