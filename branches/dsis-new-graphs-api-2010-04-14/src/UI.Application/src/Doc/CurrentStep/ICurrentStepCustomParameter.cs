using DSIS.Scheme.Ctx;

namespace DSIS.UI.Application.Doc.CurrentStep
{
  public interface ICurrentStepCustomParameter
  {
    string Name { get; }
    
    /// <summary>
    /// <see cref="StepOrders"/> for default order values
    /// </summary>
    int Order { get; }
    
    bool IsAvailable(Context ctx);

    /// <summary>
    /// New lines from Environment.NewLine will be replaces with proper html elements
    /// to preserve new line
    /// </summary>
    /// <param name="ctx">Current document context</param>
    /// <returns></returns>
    string GetValue(Context ctx);
  }
}