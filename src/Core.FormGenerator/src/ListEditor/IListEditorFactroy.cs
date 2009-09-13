using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.ListEditor
{
  public interface IListEditorFactroy
  {
    Control CreateListEditorControl<T>(IList<T> data, Func<T, string> presentor);
  }
}