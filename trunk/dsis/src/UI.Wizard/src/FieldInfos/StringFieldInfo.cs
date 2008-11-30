using System;
using System.Reflection;
using System.Windows.Forms;
using DSIS.UI.Wizard.FieldInfos;
using DSIS.UI.Wizard.FormsGenerator;
using log4net;

namespace DSIS.UI.Wizard.FieldInfos
{
  public class StringFieldInfo : FieldInfoBase
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof(FormGenerator));

    protected StringFieldInfo(PropertyInfo property, object instance) : base(property, instance)
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
                                   FireError(null);
                                 }
                                 catch (Exception e)
                                 {
                                   LOG.Error("Parsing text input", e);
                                   FireError("Failed to set value. " + e.Message);
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