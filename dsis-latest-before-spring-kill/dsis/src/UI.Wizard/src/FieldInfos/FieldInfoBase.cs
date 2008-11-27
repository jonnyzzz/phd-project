using System;
using System.Reflection;
using System.Windows.Forms;

namespace DSIS.UI.Wizard.FieldInfos
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

    protected abstract Control CreateControl();

    protected void FireError(Control control, string message)
    {
      if (ValueChanged != null)
        ValueChanged(this, control, message);
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
      set { myProperty.SetValue(myInstance, value, null); }
    }

    protected Type PropertyType
    {
      get { return myProperty.PropertyType; }
    }
  }
}