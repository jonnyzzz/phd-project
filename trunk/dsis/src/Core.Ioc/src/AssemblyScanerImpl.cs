using System;
using System.Collections.Generic;
using System.Reflection;
using DSIS.Utils;

namespace DSIS.Core.Ioc
{
  public class AssemblyScanerImpl : IAssemblyScaner
  {
    public IEnumerable<Pair<Type, T>> LoadTypes<T>(Assembly a) where T : Attribute
    {
      var list = new List<Pair<Type, T>>();
      foreach (var type in a.GetTypes())
      {
        if (!type.IsDefined(typeof (T), true))
          continue;

        var attr = (T) type.GetCustomAttributes(typeof (T), true)[0];

        list.Add(Pair.Create(type, attr));
      }
      return list;
    }
  }
}