using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.Api;

namespace EugenePetrenko.Core.FormGenerator.ListEditor
{
  public interface IListEditorFactroy
  {
    Control CreateListEditorControl<T>(IList<T> data, Func<T, string> presentor);

    Control CreateDefaultEditorControl<T>(IFormDialogGeneratorFactory dialogGen, IList<T> data)
      where T : new();
  }
}