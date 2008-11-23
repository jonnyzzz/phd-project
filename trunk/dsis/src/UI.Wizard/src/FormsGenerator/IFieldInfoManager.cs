using System.Reflection;
using DSIS.Utils.Bean;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public interface IFieldInfoManager
  {
    IFieldInfo CreateFieldInfo(object instance, PropertyInfo info);
  }
}