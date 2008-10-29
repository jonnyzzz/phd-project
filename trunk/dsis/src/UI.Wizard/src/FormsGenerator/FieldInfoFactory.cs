using System.Reflection;
using DSIS.Utils.Bean;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class FieldInfoFactory
  {
    public FieldInfoBase CreateFieldInfo(object instance, PropertyInfo info, IncludeGenerateAttribute attr)
    {
      if (info.PropertyType == typeof(string))
      {
        return new TextFieldInfo(attr.Title, attr.Description, info, instance);
      }
      if (info.PropertyType == typeof(double))
      {
        return new DoubleFieldInfo(attr.Title, attr.Description, info, instance);
      }
      if (info.PropertyType == typeof(bool))
      {
        return new BooleanFieldInfo(attr.Title, attr.Description, info, instance);
      }
      return new NonEditableFieldInfo(attr.Title, attr.Description, info, instance);
    }
  }
}