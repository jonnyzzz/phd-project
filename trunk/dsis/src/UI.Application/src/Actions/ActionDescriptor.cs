using System;
using System.Xml;
using DSIS.Utils;

namespace DSIS.UI.Application.Actions
{
  public class ActionDescriptor
  {
    public const string ELEMENT_NAME = "Action";

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

    public static ActionDescriptor FromXml(XmlElement action, ActionDescriptor parentAction)
    {
      if (action.Name != ELEMENT_NAME)
        throw new ArgumentException("Wrong xml");

      var actionId = action.GetAttribute("Id");
      var parentId = action.GetAttribute("Parent");
      if (String.IsNullOrEmpty(parentId) && parentAction != null)
        parentId = parentAction.ActionId;

      var ancor = action.GetAttribute("Ancor");
      var title = action.GetAttribute("Title");
      var description = Util.Safe(action.SelectSingleNode("description/text()"), string.Empty, x => x.Value);

      return new ActionDescriptor(actionId, parentId, ancor, description, title);
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