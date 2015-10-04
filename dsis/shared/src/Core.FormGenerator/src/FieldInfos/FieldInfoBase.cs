using System;
using System.Reflection;
using System.Windows.Forms;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  public abstract class FieldInfoBase : IFieldInfo
  {
    private readonly PropertyInfo myProperty;
    private readonly object myInstance;

    private Control myControl;

    protected FieldInfoBase(PropertyInfo property, object instance)
    {
      myInstance = instance;
      myProperty = property;
    }

    public event FieldValueChanged ValueChanged;

    /// <summary>
    /// Create control that is subscribed to value change.
    /// On change set changed value to Value property or
    /// throw an error using <code>FireError</code>.
    /// 
    /// Setting value may throw a error too.
    /// </summary>
    /// <returns>control</returns>
    protected abstract Control CreateControl();

    protected void FireError(string message)
    {
      if (ValueChanged != null)
        ValueChanged(this, myControl, message);
    }

    public Control EditorControl()
    {
      if (myControl == null)
      {
        myControl = CreateControl();
      }
      return myControl;
    }

    protected object Value
    {
      get { return myProperty.GetValue(myInstance, null); }
      set
      {
        myProperty.SetValue(myInstance, value, null);
      }
    }

    protected Type PropertyType
    {
      get { return myProperty.PropertyType; }
    }

    public T GetCustomAttribute<T>() where T : Attribute
    {
      return myProperty.GetCustomAttribute<T>();
    }
  }
}