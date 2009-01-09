namespace DSIS.UI.Wizard.ListSelector
{
  public class ItemDescr
  {
    public readonly string Title;
    public readonly string Description;

    public ItemDescr(string title, string description)
    {
      Title = title;
      Description = description;
    }

    public ItemDescr(string title)
      : this(title, "")
    {
    }
  }

  public static class ListInfo
  {
    public static ListInfo<Q> Create<Q>(string title, string description, bool enabled, Q value)
    {
      return new ListInfo<Q>(new ItemDescr(title, description), value, enabled);
    }

    public static ListInfo<Q> Create<Q>(ItemDescr title, bool enabled, Q value)
    {
      return new ListInfo<Q>(title, value, enabled);
    }
  }

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