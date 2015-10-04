using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Shared.Core.Ioc.JC
{
  public class AutowireLookupImpl : IAutowireLookupImpl
  {
    private readonly IBaseTypesLookup myLookup;

    public AutowireLookupImpl(IBaseTypesLookup lookup)
    {
      myLookup = lookup;
    }

    private IEnumerable<PropertyInfo> CollectProperties(Type type)
    {
      var set = new HashSet<PropertyInfo>();
      foreach (var clazz in myLookup.GetBaseClasses(type))
      {
        var info = clazz.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        set.UnionWith(info.Where(x => AttributeUtil.IsDefined<AutowireAttribute>(x) && x.GetSetMethod(true) != null));
      }
      return set;
    }

    public IEnumerable<Autowiring> GetAutowings(object obj)
    {
      if (obj == null)
        throw new ArgumentNullException("obj");

      return CollectProperties(obj.GetType()).Select(x => (Autowiring) new PropertyAutowiring(obj, x));
    }
  }
}