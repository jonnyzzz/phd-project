using System.Reflection;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  public class SetterInputConnectionPoint<T> : InputConnectionBase<T>
  {
    private readonly MethodInfo myProperty;

    public SetterInputConnectionPoint(string name, object @object, MethodInfo property)
      : base(@object, name)
    {
      myProperty = property;
    }

    public override void DataReady(T obj)
    {
      //todo: Reflection
      myProperty.Invoke(myObject, new object[] { obj });
    }
  }
}