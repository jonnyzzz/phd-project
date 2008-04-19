using System.Reflection;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  public interface IOutputObjectConnectionPointFactoryExtension
  {    
    IOutputConnectionPoint Output(string name, object instance, MemberInfo member);
  }
  
  public interface IInputObjectConnectionPointFactoryExtension
  {
    IInputConnectionPoint Input(string name, object instance, MemberInfo member);    
  }
}