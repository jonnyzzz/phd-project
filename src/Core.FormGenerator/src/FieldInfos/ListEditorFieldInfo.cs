using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.Api;
using EugenePetrenko.Core.FormGenerator.ListEditor;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  public class ListEditorFieldInfo : FieldInfoBase
  {
    private readonly IListEditorFactroy myFactory;
    private readonly Func<IFormDialogGeneratorFactory> myDialog;

    public ListEditorFieldInfo(IListEditorFactroy factory, PropertyInfo property, object instance, Func<IFormDialogGeneratorFactory> dialog) : base(property, instance)
    {
      myFactory = factory;
      myDialog = dialog;
    }

    protected override Control CreateControl()
    {
      if (!PropertyType.IsGenericType || PropertyType.GetGenericTypeDefinition() != typeof(IList<>))
        throw new Exception("Type should be IList<?>");

      var type = PropertyType.GetGenericArguments()[0];
      var method = GetType().GetMethod("CreateControl");
      return (Control) method.MakeGenericMethod(type).Invoke(this, new[]{Value});
    }

    [Used]
    public Control CreateControl<T>(IList<T> data)
      where T : class, new()
    {
      return myFactory.CreateDefaultEditorControl(myDialog(), data);
    }
  }
}