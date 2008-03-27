using DSIS.Scheme.Exec;

namespace DSIS.Scheme.Exec
{
  public interface IActionGraphPartBuilder : IActionGraphBuilder
  {
    ISimpleAction Start { get; }
    ISimpleAction End { get; }
  }
}