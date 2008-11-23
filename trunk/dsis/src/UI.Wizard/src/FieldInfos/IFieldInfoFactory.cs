using System;
using System.Reflection;

namespace DSIS.UI.Wizard.FieldInfos
{
  public interface IFieldInfoFactory
  {
    bool Matches(Type t);

    IFieldInfo CreateField(object instance, PropertyInfo info);
  }
}