namespace DSIS.UI.Wizard.ListSelector
{
  public class ListInfo<Q> : IListInfo<Q>
  {
    private readonly bool myEnabled;
    private readonly ItemDescr myTitle;
    private readonly Q myValue;

    public ListInfo(ItemDescr title, Q value, bool enabled)
    {
      myEnabled = enabled;
      myTitle = title;
      myValue = value;
    }

    public bool Enabled
    {
      get { return myEnabled; }
    }

    public string Description
    {
      get { return myTitle.Description; }
    }

    public string Title
    {
      get { return myTitle.Title; }
    }

    public Q Value
    {
      get { return myValue; }
    }
  }
}