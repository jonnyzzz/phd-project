using System.Collections.Generic;
using System.Text;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Exec
{
  public class ContextMissmatchException : ActionGraphException
  {
    private readonly ICollection<ContextMissmatch> myErrors;
    private readonly IAction myAction;
    private readonly Context myContext;

    public ContextMissmatchException(ICollection<ContextMissmatch> errors, IAction action, Context ctx)
      : base(Msg(errors, action, ctx))
    {
      myErrors = errors;
      myAction = action;
      myContext = ctx;
    }

    private static string Msg(IEnumerable<ContextMissmatch> eee, IAction action, Context ctx)
    {
      var sb = new StringBuilder();
      sb.AppendFormat("Failed to perform {0} due to context missmatch ", action.GetType().Name);

      var debug = action as IActionDebug;
      if (debug != null)
      {
        sb
          .AppendLine()
          .AppendLine()
          .AppendLine("Action was created at ")
          .Append(debug.Creation.ToString())
          .AppendLine();
      }

      sb.AppendLine("Missing context keys are:"); 
      foreach (var missmatch in eee)
      {
        sb.AppendLine(missmatch.Message);
      }

      sb.AppendLine();
      sb.AppendLine("Current context keys are: ");
      sb.Append(ctx != null ? ctx.ToString() : "<null>");
        
      return sb.ToString();
    }
  }
}