using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
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
          controls.Add(new OptionPageControl(attr.Title, attr.Description, fieldInfo.EditorControl()));
        }
      }

      var control = layout.Layout(controls);
      control.Dock = DockStyle.Fill;
      Size = control.Size;
      Controls.Add(control);
    }

    private IFieldInfo CreateFieldInfo(IFieldInfoManager manager, PropertyInfo info)
    {
      var inf = manager.CreateFieldInfo(myObject, info);

      inf.ValueChanged += (_, control, message) =>
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