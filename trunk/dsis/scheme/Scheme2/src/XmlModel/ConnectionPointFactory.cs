using System.Reflection;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.XmlModel
{
  public class ConnectionPointFactory : AbstractRegistry<IConnectionPointFactoryExtension>
  {    
    public IInputConnectionPoint Input(string name, object instance, MemberInfo property)
    {
      return ForEach<IInputConnectionPoint>(delegate(IConnectionPointFactoryExtension factory)
                                              {
                                                return factory.Input(name, instance, property);
                                              });      
    }

    public IOutputConnectionPoint Output(string name, object instance, MemberInfo field)
    {
      return ForEach<IOutputConnectionPoint>(delegate(IConnectionPointFactoryExtension factory)
                                        {
                                          return factory.Output(name, instance, field);
                                        });      

    }
  }
}