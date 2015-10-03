namespace DSIS.Scheme.Exec
{
  public class ActionBuilder2Adaptor : IActionGraphBuilder2
  {
    private readonly IActionGraphPartBuilder myBuilder;

    public ActionBuilder2Adaptor(IActionGraphPartBuilder builder)
    {
      myBuilder = builder;
    }

    public IActionEdgesBuilder Start
    {
      get { return new ActionEdgesBuilderAdapter(myBuilder.Start, this); }
    }

    public IActionEdgesBuilder Finish
    {
      get { return new ActionEdgesBuilderAdapter(myBuilder.End, this); }
    }

    public IActionGraphPartBuilder Builder
    {
      get { return myBuilder; }
    }
  }
}