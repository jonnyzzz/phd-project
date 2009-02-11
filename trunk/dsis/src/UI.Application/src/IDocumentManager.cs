using DSIS.Scheme.Ctx;

namespace DSIS.UI.Application
{
  public interface IDocumentManager
  {
    void ChangeDocument(Context newContext);

    /// <summary>
    /// Same as ChangeDocument, but without.
    /// </summary>
    /// <param name="currentContext"></param>
    /// <param name="newContext"></param>
    /// <returns></returns>
    Context UpdateContext(IReadOnlyContext currentContext, Context newContext);
  }
}