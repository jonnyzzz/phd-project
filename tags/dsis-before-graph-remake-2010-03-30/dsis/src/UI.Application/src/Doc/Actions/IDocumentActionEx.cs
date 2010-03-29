namespace DSIS.UI.Application.Doc.Actions
{
  public interface IDocumentActionEx : IDocumentAction
  {
    string Caption { get; }
    string Description { get; }
  }
}