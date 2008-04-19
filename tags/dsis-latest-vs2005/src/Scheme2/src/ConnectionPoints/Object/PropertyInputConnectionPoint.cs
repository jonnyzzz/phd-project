using System.Reflection;

namespace DSIS.Scheme2.ConnectionPoints.Object
{
  /// <summary>
  /// Bound object recieves data
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class PropertyInputConnectionPoint<T> : InputConnectionBase<T>
  {
    private readonly PropertyInfo myProperty;

    public PropertyInputConnectionPoint(string name, object @object, PropertyInfo property)
      : base(@object, name)
    {
      myProperty = property;
    }

    public override void DataReady(T obj)
    {
      //todo: Reflection
      myProperty.SetValue(myObject, obj, null);
    }
  }
}