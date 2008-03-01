using System.Reflection;

namespace DSIS.Scheme2.XmlModel
{
  public interface IConnectionPointFactory
  {
    IConnectionPoint ForProperty(object instance, PropertyInfo property);
    IConnectionPoint ForField(object instance, FieldInfo field);
  }
}