namespace DSIS.Scheme.Actions
{
  public class BranchAction : AgregateAction
  {
    public BranchAction(IAction theAction, IAction branch)
    {
      Builder.AddEdge(Builder.Start, theAction);
      Builder.AddEdge(theAction, Builder.End);
      Builder.AddEdge(Builder.Start, branch);
      Builder.AddEdge(theAction, branch);
    }
  }
}