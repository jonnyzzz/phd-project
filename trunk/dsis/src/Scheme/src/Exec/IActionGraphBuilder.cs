namespace DSIS.Scheme.Exec
{
  public interface IActionGraphBuilder
  {
    void AddEdge(IAction a, IAction b);
  }
}