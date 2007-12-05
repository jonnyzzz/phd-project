using System.Collections.Generic;
using System.Text;

namespace DSIS.Scheme.Exec
{
  public class ContextMissmatchException : ActionGraphException
  {
    private readonly ICollection<ContextMissmatch> myErrors;

    public ContextMissmatchException(ICollection<ContextMissmatch> errors)
      : base(Msg(errors))
    {
      myErrors = errors;
    }

    private static string Msg(IEnumerable<ContextMissmatch> eee)
    {
      StringBuilder sb = new StringBuilder();
      foreach (ContextMissmatch missmatch in eee)
      {
        sb.AppendLine(missmatch.Message);
      }
      return sb.ToString();
    }
  }
}