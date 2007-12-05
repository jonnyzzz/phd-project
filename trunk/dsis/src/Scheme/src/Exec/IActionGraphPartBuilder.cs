using DSIS.Scheme.Exec;

namespace DSIS.Scheme.Exec
{
  public interface IActionGraphPartBuilder : IActionGraphBuilder
  {
    IAction Start { get; }
    IAction End { get; }
  }
}