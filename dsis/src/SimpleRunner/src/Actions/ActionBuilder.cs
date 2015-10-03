using System.Xml;

namespace DSIS.SimpleRunner.Actions
{
  public delegate void PerformAction(XmlElement element);

  public class ActionBuilder
  {
    private readonly RootAction myRoot = new RootAction(new XmlDocument());  
    private readonly OperationStack<XmlElement> myStack = new OperationStack<XmlElement>();

    public void StartOperation(string name)
    {
      myStack.Push(AppendElement(myStack.Peek(), name), name);
    }

    public void FinishOperation(string name)
    {
      myStack.Pop(name);
    }

    public void PerformOperation(PerformAction action, string name)
    {
      StartOperation(name);
      try
      {
        action(myStack.Peek());
      } finally
      {
        FinishOperation(name);
      }
    }

    private static XmlElement AppendElement(XmlNode element, string name)
    {
      return (XmlElement)element.AppendChild(element.OwnerDocument.CreateElement(name));
    }
  }
}