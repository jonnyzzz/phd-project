using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EugenePetrenko.Core.FormGenerator.Api;

namespace EugenePetrenko.Core.FormGenerator.ListEditor
{
  public class DefaultListEditorUI<T> : IListEditorUI<T>
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

    public virtual T CreateNewItem()
    {
      //This will throw an exception of T not new()
      //Probably it is worth using TypeInstantiator here
      return (T) Activator.CreateInstance(typeof (T));
    }

    public bool OpenEditor(T data, Control parent)
    {
      return myDialog.CreateDialog(data).ShowDialog(parent) == DialogResult.OK;
    }

    public virtual string Present(T data)
    {
      return data.ToString();
    }
  }
}