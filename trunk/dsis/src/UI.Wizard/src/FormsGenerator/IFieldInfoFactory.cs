using System;
using System.Reflection;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public interface IFieldInfoFactory
  {
    bool Matches(Type t);

    IFieldInfo CreateField(object instance, PropertyInfo info);
  }
}