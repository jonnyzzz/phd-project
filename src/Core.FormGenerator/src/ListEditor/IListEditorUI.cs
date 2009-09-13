using System.Collections.Generic;
using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.ListEditor
{
  public interface IListEditorUI<T>
  {
    List<T> Data { get;}

    T CreateNewItem();

    bool OpenEditor(T data, Control parent);

    string Present(T data);
  }
}