using System;
using System.Reflection;

namespace DSIS.UI.Wizard.FieldInfos
{
  public interface IFieldInfoFactory
  {
    bool Matches(Type t, PropertyInfo info);

    IFieldInfo CreateField(object instance, PropertyInfo info);
  }
}