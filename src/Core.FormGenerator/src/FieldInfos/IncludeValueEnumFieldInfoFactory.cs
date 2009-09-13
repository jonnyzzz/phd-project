using System;
using System.Linq;
using System.Reflection;
using EugenePetrenko.Core.FormGenerator.Api;
using EugenePetrenko.Core.FormGenerator.ListSelector;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  [ComponentImplementation]
  public class IncludeValueEnumFieldInfoFactory : IFieldInfoFactory
  {
    private readonly IListSelectorFactory myFactory;

    public IncludeValueEnumFieldInfoFactory(IListSelectorFactory factory)
    {
      myFactory = factory;
    }

    public bool Matches(Type t, PropertyInfo info)
    {
      return t.IsEnum || info.IsDefined<IncludeValuesProviderAttribute>();
    }

    public IFieldInfo CreateField(object instance, PropertyInfo info)
    {
      var types = info.GetCustomAttribute<IncludeValuesProviderAttribute>();
      
      if (types == null)
      {
        if (info.PropertyType.IsEnum)
        {
          types = new IncludeValuesProviderAttribute(info.PropertyType);
        }
        else
        {
          throw new ArgumentException("Object of type " + instance.GetType() + " does not provide " +
                                      typeof (IncludeValuesProviderAttribute));
        }
      }

      var fields = types.Types.SelectMany(x => x.GetFields(BindingFlags.Public | BindingFlags.Static));
      var props = types.Types.SelectMany(x => x.GetProperties(BindingFlags.Public | BindingFlags.Static));

      return new EnumFieldInfo<object>(
        info, instance, myFactory,
        f => (fields.Where(x => x.IsDefined<IncludeValueAttribute>()).Select(
               x =>
                 {
                   var gen = x.GetCustomAttribute<IncludeValueAttribute>();
                   var obj = x.GetValue(null);
                   return ListInfo.Create(gen.Title, gen.Description, true, f(obj));
                 }))
               .Merge(
               props.Where(x=>x.IsDefined<IncludeValueAttribute>()).Select(
                 x=>{
                      var gen = x.GetCustomAttribute<IncludeValueAttribute>();
                      var obj = x.GetValue(null, null);
                      return ListInfo.Create(gen.Title, gen.Description, true, f(obj));
                 })));
    }
  }
}