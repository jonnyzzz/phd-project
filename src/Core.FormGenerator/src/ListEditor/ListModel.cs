using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EugenePetrenko.Shared.Utils;

namespace EugenePetrenko.Core.FormGenerator.ListEditor
{
  public class ListModel<T> : IEditorControlModel
  {
    private readonly IList<T> myData;
    private readonly Func<T, string> myPresentor;

    private ListBox myControl;

    public ListModel(IList<T> data, Func<T, string> presentor)
    {
      myData = data;
      myPresentor = presentor;
    }

    public Control Control
    {
      get { return myControl; }
    }

    public event EventHandler<EventArgs> RefereshRequired;

    public Control CreateControl()
    {
      var lb = new ListBox();
      myControl = lb;
      UpdateItems();
      lb.SelectedIndexChanged += delegate { FireChanged(); };
      return lb;
    }

    protected void UpdateItems()
    {
      using(TryFinally.Action(myControl.BeginUpdate, myControl.EndUpdate))
      {
        var data = new List<Item>();
        int idx = 0;

        var selectedItem = SelectedItem;
        var prevSelected = selectedItem == null ? default(T) : selectedItem.Data;

        foreach (var x in myData)
        {
          data.Add(new Item(idx++, x, myPresentor(x)));
        }
        myControl.Items.Clear();
        myControl.Items.AddRange(data.ToArray());

        foreach (Item item in myControl.Items.OfType<Item>())
        {
          if (Equals(item.Data, prevSelected))
          {
            myControl.SelectedItem = item;
            break;
          }
        }        
      }
      FireChanged();
    }

    public virtual bool AddEnabled
    {
      get { return false; }
    }

    public virtual bool EditEnabled
    {
      get { return false; }
    }

    public bool DeleteEnabled
    {
      get { return SelectedItem != null; }
    }

    protected Item SelectedItem
    {
      get
      {
        return myControl.SelectedItem as Item;
      }
    }

    public virtual void AddAction()
    {      
    }

    public virtual void EditAction()
    {
    }

    public void DeleteAction()
    {
      Item it = SelectedItem;
      if (it != null)
      {
        myData.RemoveAt(it.Index);
      }
      
      UpdateItems();
    }

    protected void FireChanged()
    {
      if (RefereshRequired != null)
      {
        RefereshRequired(this, EventArgs.Empty);
      }
    }

    protected class Item
    {
      private readonly int myIndex;
      private readonly T myData;
      private readonly string myText;

      public Item(int idx, T data, string text)
      {
        myIndex = idx;
        myData = data;
        myText = text;
      }

      public int Index
      {
        get { return myIndex; }
      }

      public T Data
      {
        get { return myData; }
      }

      public override string ToString()
      {
        return myText;
      }
    }
  }
}