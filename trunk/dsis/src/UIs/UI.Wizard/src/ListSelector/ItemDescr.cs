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
}