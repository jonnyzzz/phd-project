namespace DSIS.UI.FunctionDialog.UI
{
  public static class ListInfo
  {
    public static ListInfo<Q> Create<Q>(string title, string description, bool enabled, Q value)
    {
      return new ListInfo<Q>(description, title, value, enabled);
    }
  }

  public class ListInfo<Q> : IListInfo<Q>
  {
    private readonly bool myEnabled;
    private readonly string myDescription;
    private readonly string myTitle;
    private readonly Q myValue;

    public ListInfo(string description, string title, Q value, bool enabled)
    {
      myDescription = description;
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
      get { return myDescription; }
    }

    public string Title
    {
      get { return myTitle; }
    }

    public Q Value
    {
      get { return myValue; }
    }
  }
}