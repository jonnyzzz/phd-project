using System.Collections.Generic;
using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.Api;

namespace EugenePetrenko.Core.FormGenerator.ListEditor
{
  public class DefaultListEditorUI<T> : IListEditorUI<T>
    where T : new()
  {
    private readonly IList<T> myData;
    private readonly IFormDialogGeneratorFactory myDialog;

    public DefaultListEditorUI(IList<T> data, IFormDialogGeneratorFactory dialog)
    {
      myData = data;
      myDialog = dialog;
    }

    public IList<T> Data
    {
      get { return myData; }
    }

    public T CreateNewItem()
    {
      return new T();
    }

    public bool OpenEditor(T data, Control parent)
    {
      return myDialog.CreateDialog(data).ShowDialog(parent) == DialogResult.OK;
    }

    public string Present(T data)
    {
      return data.ToString();
    }
  }
}