using System;
using System.Reflection;
using System.Windows.Forms;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class BooleanFieldInfo : FieldInfoBase
  {
    public BooleanFieldInfo(string caption, string description, PropertyInfo property, object instance) : base(caption, description, property, instance)
    {
      if (PropertyType != typeof(bool))
        throw new ArgumentException("Boolean type expected but was " + PropertyType + " for " + property);
    }

    protected override Control CreateControl()
    {
      var control = new CheckBox {Checked = (bool) Value};
      control.CheckedChanged += delegate
                                  {
                                    Value = control.Checked;
                                  };
      return control;
    }
  }
}