namespace DSIS.Scheme.Impl.Exec
{
  public interface IActionGraphBuilder
  {
    void AddEdge(IAction a, IAction b);
  }
}