using System.Reflection;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.XmlModel
{
  public class ConnectionPointFactory : IConnectionPointFactory
  {
    public IConnectionPoint ForProperty(object instance, PropertyInfo property)
    {
      return null;
    }    

    public IConnectionPoint ForField(object instance, FieldInfo field)
    {
      return null;
    }    
  }
}