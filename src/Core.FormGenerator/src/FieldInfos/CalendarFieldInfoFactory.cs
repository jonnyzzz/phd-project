using System;
using System.Reflection;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  [ComponentImplementation]
  public class CalendarFieldInfoFactory : IFieldInfoFactory
  {
    public bool Matches(Type t, PropertyInfo info)
    {
      return t == typeof (DateTime);
    }

    public IFieldInfo CreateField(object instance, PropertyInfo info)
    {
      return new CalendarFieldInfo(info, instance);
    }
  }
}