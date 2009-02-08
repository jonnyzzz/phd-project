using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using DSIS.Scheme.Objects.Systemx;
using DSIS.UI.UI;
using DSIS.UI.Wizard.FieldInfos;
using DSIS.Utils;
using DSIS.Utils.Bean;

namespace DSIS.UI.Wizard.FormsGenerator
{
  public class FormGenerator : UserControl, IErrorProvider<bool>
  {
    private readonly Type myType;
    private readonly object myObject;
    private readonly ErrorProvider myErrorProvider;

    private readonly HashSet<IFieldInfo> myPendingErrors = new HashSet<IFieldInfo>();
    private readonly Dictionary<string, IFieldInfo> myPropertyToControl = new Dictionary<string, IFieldInfo>();

    public FormGenerator(IFieldInfoManager manager, object obj, IOptionPageLayout layout)
    {
      myObject = obj;
      myType = myObject.GetType();
      myErrorProvider = new ErrorProvider(this);

      Padding = new Padding(5,5,5,5);
      var controls = new List<IOptionPageControl>();

      foreach (var info in myType.GetProperties())
      {
        var attr = info.OneInstance<IncludeGenerateAttribute>();
        if (attr != null)
        {
          var fieldInfo = CreateFieldInfo(manager, info);
          myPropertyToControl.Add(info.Name, fieldInfo);
          controls.Add(new OptionPageControl(attr.Title, attr.Description, fieldInfo.EditorControl()));
        }
      }

      if (controls.Count > 0)
      {
        layout.Layout(this, controls);
      } else
      {
        Controls.Add(new Label
                       {
                         Text = "This object does not provide any options",
                         Dock = DockStyle.Fill
                       });
      }
    }

    private IFieldInfo CreateFieldInfo(IFieldInfoManager manager, PropertyInfo info)
    {
      var inf = manager.CreateFieldInfo(myObject, info);

      inf.ValueChanged += (_, control, message) =>
                      {
                        if (message != null)
                        {                          
                          myErrorProvider.SetError(control, null);
                        }

                        myErrorProvider.SetError(control, message);
                        myErrorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
                        myErrorProvider.SetIconPadding(control, -10);
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
      if (myObject is IOptionsValueChecker)
      {
        foreach (var value in myPropertyToControl.Values)
        {
          value.CheckFieldValue();
        }
      }
      return myPendingErrors.Count == 0;
    }

    private class OptionPageControl : IOptionPageControl
    {
      private readonly string myTitle;
      private readonly string myDescr;
      private readonly Control myControl;

      public OptionPageControl(string title, string descr, Control control)
      {
        myTitle = title;
        myDescr = descr;
        myControl = control;
      }

      public string Title
      {
        get { return myTitle; }
      }

      public string Description
      {
        get { return myDescr; }
      }

      public Control Control
      {
        get { return myControl; }
      }
    }
  }
}