using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using DSIS.UI.UI;
using DSIS.Utils;
using DSIS.Utils.Bean;
using log4net;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class FormGenerator : UserControl, IErrorProvider<bool>
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (FormGenerator));

    private readonly Type myType;
    private readonly object myObject;
    private readonly ErrorProvider myErrorProvider;

    private readonly List<FieldInfo> myPendingErrors = new List<FieldInfo>();

    public FormGenerator(object obj)
    {
      myObject = obj;
      myType = myObject.GetType();
      myErrorProvider = new ErrorProvider(this);

      Padding = new Padding(5,5,5,5);
      var controls = new List<Control>();

      foreach (var info in myType.GetProperties())
      {
        var attr = info.OneInstance<IncludeGenerateAttribute>();
        if (attr != null)
        {
          AddAttribute(controls, new FieldInfo(attr.Title, attr.Description, info, myObject));
        }
      }

      controls.Reverse();
      foreach (var control in controls)
      {
        Controls.Add(control);
      }
    }

    bool IErrorProvider<bool>.Validate()
    {
      return myPendingErrors.Count == 0;
    }

    private void AddAttribute(ICollection<Control> host, FieldInfo info)
    {
      var panel = new Panel
                    {
                      Dock = DockStyle.Top, 
                      Width = 150,
                      Padding = new Padding(0,0,5,0),
                      Height = 25
                    };
      var caption = new Label
                      {
                        Text = info.Caption, 
                        Width = 70, 
                        Dock = DockStyle.Left, 
                      };
      var field = new TextBox
                    {
                      Text = info.ValueString, 
                      Width = 150, 
                      Dock = DockStyle.Left
                    };
      field.TextChanged += delegate
      {
        try
        {
          info.TrySetValue(field.Text);
          myErrorProvider.SetError(field, null);
          myPendingErrors.Remove(info);
        }
        catch (Exception e)
        {
          LOG.Error("Parsing text input", e);
          myErrorProvider.SetError(field, "Failed to set value. " + e.Message);
          myPendingErrors.Add(info);
        }
      };

      panel.Controls.Add(field); 
      panel.Controls.Add(caption); 
      

      host.Add(panel);
      
      if (info.Description != null)
      {
        var label = new Label
                      {
                        Padding = new Padding(10, 0, 0, 0),
                        Dock = DockStyle.Top,
                        Text = info.Description
                      };

        host.Add(label);
      }
    }

    private class FieldInfo
    {
      private readonly PropertyInfo myProperty;
      private readonly object myInstance;

      public readonly string Caption;
      public readonly string Description;

      public FieldInfo(string caption, string description, PropertyInfo property, object instance)
      {
        Caption = caption;
        myInstance = instance;
        myProperty = property;
        Description = description;
      }

      public void TrySetValue(string value)
      {
        //todo: Use TypeConverter here
        if (myProperty.PropertyType == typeof(double))
        {
          myProperty.SetValue(myInstance, double.Parse(value), null);
        }
      }

      public string ValueString
      {
        get { return (myProperty.GetValue(myInstance, null) ?? string.Empty).ToString(); }
      }
    }
  }
}