using System.Collections.Generic;
using System.Xml;

namespace DSIS.SimpleRunner.Actions
{
  public class RootAction : ActionBase
  {
    protected readonly XmlDocument Document;

    public RootAction(XmlDocument document)
    {
      Document = document;
      SetElement(Document.DocumentElement);
    }

    public override string Name
    {
      get { return "dsis-eugene-petrenko"; }
    }
  }
}