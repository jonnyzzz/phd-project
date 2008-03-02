using System.Reflection;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  public interface IObjectConnectionPointFactoryExtension
  {
    IInputConnectionPoint Input(string name, object instance, MemberInfo member);
    IOutputConnectionPoint Output(string name, object instance, MemberInfo member);
  }
}