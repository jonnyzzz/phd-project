using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  public class AssemblyScanerImpl : IAssemblyScaner
  {
    private readonly ITypesFilter myFiler;
    private readonly Dictionary<Assembly, Hashset<Type>> myTypesCache = new Dictionary<Assembly, Hashset<Type>>();

    public AssemblyScanerImpl(ITypesFilter filer)
    {
      myFiler = filer;
    }

    public IEnumerable<Pair<Type, T>> LoadTypes<T>(Assembly a) where T : Attribute
    {
      Hashset<Type> list = GetAllTypes(a);

      var result = new List<Pair<Type, T>>();
      foreach (var type in list)
      {
        if (!type.IsDefined(typeof(T), true))
          continue;

        var attr = (T)type.GetCustomAttributes(typeof(T), true)[0];

        result.Add(Pair.Create(type, attr));
      }
      return result;
    }

    private Hashset<Type> GetAllTypes(Assembly a)
    {
      if (!myFiler.Accept(a))
        return new Hashset<Type>();
      
      Hashset<Type> types;
      if (myTypesCache.TryGetValue(a, out types))
        return types;
      
      var list = new Hashset<Type>();
      var queue = new Queue<Type>(a.GetTypes());

      for (Type type = queue.Dequeue(); queue.Count > 0; type = queue.Dequeue())
      {
        if (!list.Contains(type) && myFiler.Accept(type))
        {
          list.Add(type);
          foreach (var nestedType in type.GetNestedTypes())
          {
            if (myFiler.Accept(nestedType))
              queue.Enqueue(nestedType);
          }
        }
      }
      return myTypesCache[a] = list;
    }
  }
}