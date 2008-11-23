using System.Collections.Generic;
using System.Reflection;
using DSIS.Core.Ioc;

namespace DSIS.UI.Wizard.FormsGenerator
{
  [ComponentImplementation]
  public class FieldInfoManager : IFieldInfoManager
  {
    private readonly IEnumerable<IFieldInfoFactory> myFieldInfos;

    public FieldInfoManager(IEnumerable<IFieldInfoFactory> fieldInfos)
    {
      myFieldInfos = fieldInfos;
    }

    public IFieldInfo CreateFieldInfo(object instance, PropertyInfo info)
    {
      foreach (var fi in myFieldInfos)
      {
        if (fi.Matches(info.PropertyType))
        {
          return fi.CreateField(instance, info);
        }
      }
      return new NonEditableFieldInfo(info, instance);
    }
  }
}