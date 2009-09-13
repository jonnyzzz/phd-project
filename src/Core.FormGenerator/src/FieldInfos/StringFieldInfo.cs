using System;
using System.Reflection;
using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.FieldInfos;
using log4net;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  public class StringFieldInfo : FieldInfoBase
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof(Impl.FormGenerator));

    protected StringFieldInfo(PropertyInfo property, object instance) : base(property, instance)
    {
    }

    protected sealed override Control CreateControl()
    {
      var control = new TextBox {Text = GetValueString()};
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
      
      return UpdateTextBox(control);
    }

    protected virtual Control UpdateTextBox(TextBox box)
    {
      return box;
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