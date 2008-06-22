using DSIS.Utils;

namespace DSIS.Scheme.Exec
{
  public class ActionEdgesBuilderAdapter : IActionEdgesBuilder
  {
    private readonly IAction myAction;
    private readonly ActionBuilder2Adaptor myGraph;

    public ActionEdgesBuilderAdapter(IAction action, ActionBuilder2Adaptor graph)
    {
      myAction = action;
      myGraph = graph;
    }

    public IActionEdgesBuilder Edge(IAction action)
    {
      myGraph.Builder.AddEdge(myAction, action);
      return new ActionEdgesBuilderAdapter(action, myGraph);
    }

    public IActionEdgesBuilder Edge(IActionEdgesBuilder id)
    {
      var cid = (ActionEdgesBuilderAdapter) id;
      myGraph.Builder.AddEdge(myAction, cid.myAction);
      return this;
    }

    public IActionEdgesBuilder With(DAction<IActionEdgesBuilder> closure)
    {
      closure(this);
      return this;
    }
  }
}