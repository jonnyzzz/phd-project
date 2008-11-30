using DSIS.Scheme.Ctx;

namespace DSIS.UI.Application.Doc
{
  public interface ICurrentStepCustomParameter
  {
    string Name { get; }
    bool IsAvailable(Context ctx);
    string GetValue(Context ctx);
  }
}