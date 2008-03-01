using System.Reflection;

namespace DSIS.Scheme.XmlModel
{
  public interface IConnectionPointFactory
  {
    IConnectionPoint CreateConnectionPoint(object instance, PropertyInfo property);
    IConnectionPoint CreateConnectionPoint(object instance, FieldInfo field);
  }
}