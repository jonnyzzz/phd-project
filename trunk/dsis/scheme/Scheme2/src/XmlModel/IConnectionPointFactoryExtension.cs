using System.Reflection;

namespace DSIS.Scheme2.XmlModel
{
  public interface IConnectionPointFactoryExtension
  {
    IInputConnectionPoint Input(string name, object instance, MemberInfo property);
    IOutputConnectionPoint Output(string name, object instance, MemberInfo field);
  }  
}