using System.Reflection;
using EugenePetrenko.Core.FormGenerator.FieldInfos;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  public interface IFieldInfoManager
  {
    IFieldInfo CreateFieldInfo(object instance, PropertyInfo info);
  }
}