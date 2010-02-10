using System.Reflection;

namespace DSIS.UI.Wizard.FieldInfos
{
  public interface IFieldInfoManager
  {
    IFieldInfo CreateFieldInfo(object instance, PropertyInfo info);
  }
}