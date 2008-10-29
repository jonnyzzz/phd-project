﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using DSIS.UI.UI;
using DSIS.Utils;
using DSIS.Utils.Bean;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class FormGenerator : UserControl, IErrorProvider<bool>
  {
    private readonly FieldInfoFactory myFactory = new FieldInfoFactory();

    private readonly Type myType;
    private readonly object myObject;
    private readonly ErrorProvider myErrorProvider;

    private readonly HashSet<FieldInfoBase> myPendingErrors = new HashSet<FieldInfoBase>();

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
          AddAttribute(controls, CreateFieldInfo(info, attr));
        }
      }

      controls.Reverse();
      foreach (var control in controls)
      {
        Controls.Add(control);
      }
    }

    private FieldInfoBase CreateFieldInfo(PropertyInfo info, IncludeGenerateAttribute attr)
    {
      var inf = myFactory.CreateFieldInfo(myObject, info, attr);

      inf.Error += (control, message) =>
                      {
                        myErrorProvider.SetError(control, message);
                        if (message != null)
                        {
                          myPendingErrors.Add(inf);
                        } else
                        {
                          myPendingErrors.Remove(inf);
                        }
                      };
      return inf;
    }

    bool IErrorProvider<bool>.Validate()
    {
      return myPendingErrors.Count == 0;
    }

    private static void AddAttribute(ICollection<Control> host, FieldInfoBase info)
    {
      var panel = new Panel
                    {
                      Dock = DockStyle.Top, 
                      Width = 150,
                      Padding = new Padding(0,0,5,5),
                      Height = 25
                    };
      var caption = new Label
                      {
                        Text = info.Caption, 
                        Width = 70, 
                        Dock = DockStyle.Left, 
                      };
      var field = info.EditorControl();
      field.Width = 150;
      field.Dock = DockStyle.Left;

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
  }
}