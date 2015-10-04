using System.Collections.Generic;
using System.Windows.Forms;

namespace EugenePetrenko.Core.FormGenerator.Api
{
  public interface IListEditorUI<T>
  {
    IList<T> Data { get;}

    T CreateNewItem();

    bool OpenEditor(T data, Control parent);

    string Present(T data);
  }
}