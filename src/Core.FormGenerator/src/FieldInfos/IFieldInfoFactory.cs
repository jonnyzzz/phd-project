using System;
using System.Reflection;
using EugenePetrenko.Core.FormGenerator.FieldInfos;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  public interface IFieldInfoFactory
  {
    bool Matches(Type t, PropertyInfo info);

    IFieldInfo CreateField(object instance, PropertyInfo info);
  }
}