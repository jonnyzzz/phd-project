using System.Collections.Generic;
using System.Reflection;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.XmlModel
{
  public class ConnectionPointFactory
  {
    private readonly List<IConnectionPointFactoryExtension> myFactories;

    public ConnectionPointFactory(List<IConnectionPointFactoryExtension> factories)
    {
      myFactories = factories;
    }

    public IInputConnectionPoint Input(string name, object instance, MemberInfo property)
    {
      foreach (IConnectionPointFactoryExtension factory in myFactories)
      {
        IInputConnectionPoint input = factory.Input(name, instance, property);
        if (input != null)
          return input;
      }
      return null;
    }

    public IOutputConnectionPoint Output(string name, object instance, MemberInfo field)
    {
      foreach (IConnectionPointFactoryExtension factory in myFactories)
      {
        IOutputConnectionPoint output = factory.Output(name, instance, field);
        if (output != null)
          return output;
      }
      return null;
    }
  }
}