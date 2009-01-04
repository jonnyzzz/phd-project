using DSIS.Scheme.Ctx;

namespace DSIS.UI.Application
{
  public interface IDocumentManager
  {
    void ChangeDocument(Context newContext);
  }
}