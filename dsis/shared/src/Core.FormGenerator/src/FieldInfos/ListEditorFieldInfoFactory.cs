using System;
using System.Collections.Generic;
using System.Reflection;
using EugenePetrenko.Core.FormGenerator.Api;
using EugenePetrenko.Core.FormGenerator.ListEditor;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Core.FormGenerator.FieldInfos
{
  [ComponentImplementation]
  public class ListEditorFieldInfoFactory : IFieldInfoFactory
  {
    [Autowire]
    private IListEditorFactroy myFactory { get; set;}

    [Autowire]
    private Func<IFormDialogGeneratorFactory> myDialog { get; set; }

    public bool Matches(Type t, PropertyInfo info)
    {
      return t.IsGenericType && t.GetGenericTypeDefinition() == typeof (IList<>);
    }

    public IFieldInfo CreateField(object instance, PropertyInfo info)
    {
      return new ListEditorFieldInfo(myFactory, info, instance, myDialog);
    }
  }
}