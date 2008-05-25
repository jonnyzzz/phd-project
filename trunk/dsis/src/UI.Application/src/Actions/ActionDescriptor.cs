namespace DSIS.UI.Application.Actions
{
  public class ActionDescriptor : IActionDescriptor
  {
    private readonly string myActionId;
    private readonly string myAncor;
    private readonly string myTitle;
    private readonly string myDescription;
    private readonly string myParentId;

    public ActionDescriptor(string actionId, string parentActionId, string ancor, string description, string title)
    {
      myActionId = actionId;
      myAncor = ancor;
      myDescription = description;
      myParentId = parentActionId;
      myTitle = title;
    }

    public string ParentId
    {
      get { return myParentId; }
    }

    public string ActionId
    {
      get { return myActionId; }
    }

    public string Ancor
    {
      get { return myAncor; }
    }

    public string Title
    {
      get { return myTitle; }
    }

    public string Description
    {
      get { return myDescription; }
    }

    public override string ToString()
    {
      return string.Format("Action:{0}.Parent:{1},Title:{2}", ActionId, ParentId, Title);
    }
  }
}