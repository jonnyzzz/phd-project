using System.Xml;

namespace DSIS.SimpleRunner.Actions
{
  public sealed class DelegateLeafAction : LeafAction
  {
    public delegate void DLeafActionD(XmlElement element);

    private readonly DLeafActionD myAction;

    public DelegateLeafAction(XmlElement element, string name, DLeafActionD action) : base(element, name)
    {
      myAction = action;
    }

    public override void DoAction()
    {
      myAction(Element);
    }
  }
}