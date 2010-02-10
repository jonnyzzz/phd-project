namespace DSIS.Scheme.Exec
{
  public interface IActionGraphBuilder2
  {
    IActionEdgesBuilder Start { get; }
    IActionEdgesBuilder Finish { get;  }
  }
}