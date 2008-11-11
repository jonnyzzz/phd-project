
namespace DSIS.UI.Application.Doc.Actions
{
  public interface IDocumentAction
  {
    bool Compatible { get; }

    void Apply();
  }
}