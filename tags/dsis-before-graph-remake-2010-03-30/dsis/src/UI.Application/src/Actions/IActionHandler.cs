using DSIS.Scheme.Ctx;

namespace DSIS.UI.Application.Actions
{
  public interface IActionHandler
  {
    string[] ActionId { get;  }

    bool Enabled(Context ctx);

    /// <param name="ctx">Context for action. TBD</param>
    /// <returns>true if action was processes, or false to call next action handler</returns>
    bool Do(Context ctx);
  }
}