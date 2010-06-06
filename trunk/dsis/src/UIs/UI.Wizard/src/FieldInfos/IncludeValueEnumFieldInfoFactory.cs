using System;
using System.Linq;
using System.Reflection;
using DSIS.UI.Wizard.ListSelector;
using DSIS.Utils;
using DSIS.Utils.Bean;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace DSIS.UI.Wizard.FieldInfos
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
      var types = info.OneInstance<IncludeValuesProviderAttribute>();
      
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

      var fields = types.Types.Maps(x => x.GetFields(BindingFlags.Public | BindingFlags.Static));
      var props = types.Types.Maps(x => x.GetProperties(BindingFlags.Public | BindingFlags.Static));

      return new EnumFieldInfo<object>(
        info, instance, myFactory,
        f => fields.Where(x => x.IsDefined<IncludeValueAttribute>()).Map(
               x =>
                 {
                   var gen = x.OneInstance<IncludeValueAttribute>();
                   var obj = x.GetValue(null);
                   return ListInfo.Create(gen.Title, gen.Description, true, f(obj));
                 }).Join(
                 props.Where(x=>x.IsDefined<IncludeValueAttribute>()).Map(
                   x=>{
                   var gen = x.OneInstance<IncludeValueAttribute>();
                   var obj = x.GetValue(null, null);
                   return ListInfo.Create(gen.Title, gen.Description, true, f(obj));
                   })));
    }
  }
}