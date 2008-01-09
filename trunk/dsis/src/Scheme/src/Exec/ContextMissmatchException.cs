using System;
using System.Collections.Generic;
using System.Text;

namespace DSIS.Scheme.Exec
{
  public class ContextMissmatchException : ActionGraphException
  {
    private readonly ICollection<ContextMissmatch> myErrors;
    private readonly IAction myAction;

    public ContextMissmatchException(ICollection<ContextMissmatch> errors, IAction action)
      : base(Msg(errors, action))
    {
      myErrors = errors;
      myAction = action;
    }

    private static string Msg(IEnumerable<ContextMissmatch> eee, IAction action)
    {
      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("Failed to perform {0} due to context missmatch ", action.GetType().Name);

      IActionDebug debug = action as IActionDebug;
      if (debug != null)
      {
        sb.AppendLine().Append("at ").Append(debug.Creation.ToString()).AppendLine();
      }

      foreach (ContextMissmatch missmatch in eee)
      {
        sb.AppendLine(missmatch.Message);
      }
      return sb.ToString();
    }
  }
}