namespace DSIS.Scheme.Actions
{
  public interface ILoopAction
  {
    Key<LoopIndex> Key { get; }
  }

  public delegate IAction ConstructGraph(ILoopAction key);
}