using DSIS.Core.Coordinates;

namespace DSIS.Graph.Tests.FS
{
  public class TestContextWithGraphFactory<TCell> : IReadonlyGraphWith<TCell> where TCell : ICellCoordinate
  {
    private readonly TestContext<TCell> myHost;
    public ITestContextWithGraph<TCell> Context { get; set; }
    public TestContextWithGraphFactory(TestContext<TCell> host)
    {
      myHost = host;
    }

    public void With<TNode>(IReadonlyGraph<TCell, TNode> graph) where TNode : class, INode<TCell>
    {
      Context = new TestContextWithGraph<TCell, TNode>(myHost, graph);
    }
  }
}