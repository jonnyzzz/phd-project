using System.Xml;

namespace DSIS.SimpleRunner.Actions
{  
  public abstract class LeafAction : ActionBase
  {
    private readonly string myName;
    
    public LeafAction(XmlElement element, string name)
    {
      myName = name;
    }

    public override string Name
    {
      get { return myName; }
    }

    protected override void OnBeforeRun()
    {
      DoAction();
    }

    public abstract void DoAction();
  }
}