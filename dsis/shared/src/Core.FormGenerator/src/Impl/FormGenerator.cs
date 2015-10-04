using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.Api;
using EugenePetrenko.Core.FormGenerator.ErrorProvider;
using EugenePetrenko.Core.FormGenerator.FieldInfos;
using EugenePetrenko.Core.FormGenerator.Layout;
using EugenePetrenko.Shared.Core.Ioc.Api;
using EugenePetrenko.Shared.Utils;

[assembly:AssemblyWithComponents]

namespace EugenePetrenko.Core.FormGenerator.Impl
{
  public class FormGenerator : UserControl, IErrorProvider<bool>
  {
    private readonly Type myType;
    private readonly object myObject;
    private readonly System.Windows.Forms.ErrorProvider myErrorProvider;

    private readonly HashSet<IFieldInfo> myPendingErrors = new HashSet<IFieldInfo>();
    private readonly Dictionary<string, IFieldInfo> myPropertyToControl = new Dictionary<string, IFieldInfo>();

    public FormGenerator(IFieldInfoManager manager, object obj, IOptionPageLayout layout)
    {
      myObject = obj;
      myType = myObject.GetType();
      myErrorProvider = new System.Windows.Forms.ErrorProvider(this);

      Padding = new Padding(5,5,5,5);
      var controls = new List<IOptionPageControl>();

      foreach (var info in myType.GetProperties())
      {
        var attr = info.GetCustomAttribute<IncludeGenerateAttribute>();
        if (attr != null)
        {
          var fieldInfo = CreateFieldInfo(myObject, manager, info);
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

    private IFieldInfo CreateFieldInfo(object @object, IFieldInfoManager manager, PropertyInfo info)
    {
      var inf = manager.CreateFieldInfo(@object, info);

      inf.ValueChanged += (_, control, message) =>
                            {
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

    public bool ValidateData()
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