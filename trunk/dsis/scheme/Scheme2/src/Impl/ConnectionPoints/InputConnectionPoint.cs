using System.Reflection;
using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Impl.ConnectionPoints
{
  /// <summary>
  /// Bound object recieves data
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class InputConnectionPoint<T> : IInputConnectionPoint<T>
  {
    private readonly object myObject;
    private readonly string myName;
    private readonly PropertyInfo myProperty;

    public InputConnectionPoint(string name, object @object, PropertyInfo property)
    {
      myObject = @object;
      myProperty = property;
      myName = name;
    }

    public void DataReady(T obj)
    {
      myProperty.SetValue(myObject, obj, null);
    }

    public void With(IInputConnectionPointWith with)
    {
      with.Register(this);
    }

    public void Bind(IOutputConnectionPoint pt)
    {
      pt.With(new BindOutput<T>(this));
    }

    public string Name
    {
      get { return myName; }
    }    
  }
}