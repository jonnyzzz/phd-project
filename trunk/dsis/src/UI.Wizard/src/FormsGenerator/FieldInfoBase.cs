using System;
using System.Reflection;
using System.Windows.Forms;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public abstract class FieldInfoBase
  {
    private readonly PropertyInfo myProperty;
    private readonly object myInstance;

    public readonly string Caption;
    public readonly string Description;
    
    private Control myControl;

    protected FieldInfoBase(string caption, string description, PropertyInfo property, object instance)
    {
      Caption = caption;
      myInstance = instance;
      myProperty = property;
      Description = description;        
    }

    public delegate void OnError(Control control, string message);

    public event OnError Error;

    protected abstract Control CreateControl();

    protected void FireError(Control control, string message)
    {
      if (Error != null)
        Error(control, message);
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
      set { myProperty.SetValue(myInstance, value, null);}
    }

    protected Type PropertyType
    {
      get { return myProperty.PropertyType; }
    }
  }
}