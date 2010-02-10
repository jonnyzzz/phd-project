namespace DSIS.UI.Application.Actions
{
  public class SeparatorDescriptor : IActionDescriptor
  {
    private readonly string myId;
    private readonly string myParentId;
    private readonly string myAncor;

    public SeparatorDescriptor(string myId, string myParentId, string myAncor)
    {
      this.myId = myId;
      this.myParentId = myParentId;
      this.myAncor = myAncor;
    }

    public string ParentId { get { return myParentId; } }
    public string ActionId { get { return myId; } }
    public string Ancor
    {
      get { return myAncor; }
    }
  }
}