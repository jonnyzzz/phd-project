using DSIS.Scheme.Ctx;

namespace DSIS.UI.Application.Actions.Impl
{
  public interface IDocumentContextFill
  {
    string Order { get; }
    void FillContext(IReadOnlyContext info, IWriteOnlyContext context);
  }
}