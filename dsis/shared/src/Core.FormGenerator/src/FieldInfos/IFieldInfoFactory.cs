using System;
using System.Reflection;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  public interface IFieldInfoFactory
  {
    bool Matches(Type t, PropertyInfo info);

    IFieldInfo CreateField(object instance, PropertyInfo info);
  }
}