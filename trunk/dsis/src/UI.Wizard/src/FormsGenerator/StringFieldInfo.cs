using System;
using System.Reflection;
using System.Windows.Forms;
using log4net;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class StringFieldInfo : FieldInfoBase
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof(FormGenerator));

    protected StringFieldInfo(string caption, string description, PropertyInfo property, object instance) : base(caption, description, property, instance)
    {
    }

    protected sealed override Control CreateControl()
    {
      Control control = new TextBox {Text = GetValueString()};
      control.TextChanged += delegate
                               {
                                 try
                                 {
                                   TrySetValue(control.Text);
                                   FireError(control, null);
                                 }
                                 catch (Exception e)
                                 {
                                   LOG.Error("Parsing text input", e);
                                   FireError(control, "Failed to set value. " + e.Message);
                                 }
                               };
      return control;
    }

    protected virtual void TrySetValue(string value)
    {
      Value = double.Parse(value);
    }

    protected virtual string GetValueString()
    {
      return (Value ?? string.Empty).ToString();
    }
  }
}