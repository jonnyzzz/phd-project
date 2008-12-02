using System;
using System.Reflection;
using System.Windows.Forms;
using DSIS.Scheme.Objects.Systemx;

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

    public void CheckFieldValue()
    {
      OnValueChanged();
    }

    private void OnValueChanged()
    {
      var hasFired = false;
      var v = myInstance as IOptionsValueChecker;
      if (v != null)
      {
        v.HasErrors(myProperty.Name, x =>
                                       {
                                         FireError(x);
                                         hasFired = true;
                                       });
        if (!hasFired)
        {
          FireError(null);
        }
      }
    }

    protected object Value
    {
      get { return myProperty.GetValue(myInstance, null); }
      set
      {
        myProperty.SetValue(myInstance, value, null);
        OnValueChanged();
      }
    }

    protected Type PropertyType
    {
      get { return myProperty.PropertyType; }
    }
  }
}