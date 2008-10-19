namespace DSIS.UI.Application.Doc
{
  [DocumentComponent]
  public class DocumentControl : IDocumentMainControl
  {
    public DocumentControl(CurrentDocumentControl control)
    {
      Control = control;
    }

    public IControlWithTitle Control { get; private set;}
  }
}