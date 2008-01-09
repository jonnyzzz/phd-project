namespace DSIS.Scheme.Exec
{
  public interface IActionGraphBuilder
  {
    void AddEdge(IAction a, IAction b);
  }

  public class ActionBuilderAdapter : IActionGraphBuilder
  {
    private readonly IActionGraphBuilder myBuilder;

    public ActionBuilderAdapter(IActionGraphBuilder builder)
    {
      myBuilder = builder;
    }

    public void AddEdge(IAction a, IAction b)
    {
      myBuilder.AddEdge(a, b);
    }

    public IAction AddLine(params IAction[] actions)
    {
      IAction prev = null;
      foreach (IAction action in actions)
      {
        if (prev != null)
        {
           AddEdge(prev, action);
        }
        prev = action;
      }
      return prev;
    }
  }
}