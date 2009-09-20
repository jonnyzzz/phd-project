using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.Api;
using EugenePetrenko.Core.FormGenerator.ListEditor;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  public class ListEditorFieldInfo : FieldInfoBase, TypeGenerifier.Fun<object, Control>
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
      return TypeGenerifier.CallbackFun(type, this, Value);
    }

    Control TypeGenerifier.Fun<object, Control>.Callback<T>(object p)
    {
      return myFactory.CreateDefaultEditorControl(myDialog(), (IList<T>)p);
    }
  }
}