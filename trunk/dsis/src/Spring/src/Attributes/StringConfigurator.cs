using System;
using System.Reflection;
using DSIS.Spring.Assemblies;

namespace DSIS.Spring.Attributes
{
  [UsedBySpring]
  public class StringConfigurator : ITypeLoadListener
  {
    private readonly SpringXmlConfigWriter myWriter;

    public StringConfigurator(SpringXmlConfigWriter myWriter)
    {
      this.myWriter = myWriter;
    }

    public void TypeLoaded(Assembly assembly, Type[] loadedTypes)
    {
      foreach (var type in loadedTypes)
      {
        LoadType(type);
      }
    }

    private void LoadType(Type type)
    {
      foreach(SpringBeanAttribute attr in type.GetCustomAttributes(typeof(SpringBeanAttribute), true))
      {
        myWriter.RegisterBean(attr.BeanName ?? "AutoBean-" + Guid.NewGuid(), type);
      }
    }
  }
}