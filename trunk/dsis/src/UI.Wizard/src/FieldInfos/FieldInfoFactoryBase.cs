using System;
using System.Reflection;

namespace DSIS.UI.Wizard.FieldInfos
{
  public abstract class FieldInfoFactoryBase<T> : IFieldInfoFactory
  {
    public virtual bool Matches(Type t)
    {
      return typeof (T) == t;
    }

    public IFieldInfo CreateField(object instance, PropertyInfo info)
    {
      return CreateField(info, instance);
    }

    protected abstract IFieldInfo CreateField(PropertyInfo info, object instance);
  }
}