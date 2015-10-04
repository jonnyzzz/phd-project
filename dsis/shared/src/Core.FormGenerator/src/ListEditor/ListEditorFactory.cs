using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.Api;
using EugenePetrenko.Shared.Core.Ioc.Api;

namespace EugenePetrenko.Core.FormGenerator.ListEditor
{
  [ComponentImplementation]
  public class ListEditorFactory : IListEditorFactroy
  {
    public Control CreateListEditorControl<T>(IList<T> data, Func<T, string> presentor)
    {
      return new EditorControl(new ListModel<T>(data, presentor));
    }

    public Control CreateDefaultEditorControl<T>(IFormDialogGeneratorFactory dialogGen, IList<T> data)
    {
      return new EditorControl(new EditListModel<T>(new DefaultListEditorUI<T>(data, dialogGen)));
    }
  }
}