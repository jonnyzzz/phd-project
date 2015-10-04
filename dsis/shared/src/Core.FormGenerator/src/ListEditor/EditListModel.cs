using EugenePetrenko.Core.FormGenerator.Api;

namespace EugenePetrenko.Core.FormGenerator.ListEditor
{
  public class EditListModel<T> : ListModel<T>
  {
    private readonly IListEditorUI<T> myModel;

    public EditListModel(IListEditorUI<T> model) : base(model.Data, model.Present)
    {
      myModel = model;
    }

    public override bool AddEnabled
    {
      get { return true; }
    }

    public override bool EditEnabled
    {
      get { return SelectedItem != null; }
    }

    public override void AddAction()
    {
      var t = myModel.CreateNewItem();
      if (myModel.OpenEditor(t, Control))
      {
        myModel.Data.Add(t);
      }      
      UpdateItems();
    }

    public override void EditAction()
    {
      var t = SelectedItem.Data;
      myModel.OpenEditor(t, Control);
            
      UpdateItems();
    }
  }
}