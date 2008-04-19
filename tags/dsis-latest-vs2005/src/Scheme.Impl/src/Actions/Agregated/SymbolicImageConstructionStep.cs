using DSIS.Scheme.Actions;

namespace DSIS.Scheme.Impl.Actions.Agregated
{
  public class SymbolicImageConstructionStep : AgregateAction
  {
    public SymbolicImageConstructionStep()
    {
      ISimpleAction merge = new MergeComponetsAction();
      ISimpleAction buildImage = new BuildSymbolicImageAction();
      ISimpleAction components = new ChainRecurrenctSimbolicImageAction();
      ISimpleAction buildImageStartProxy = new ProxyAction();

      Builder.AddEdge(Builder.Start, merge);
      Builder.AddEdge(merge, buildImage);
      Builder.AddEdge(Builder.Start, buildImageStartProxy);
      Builder.AddEdge(buildImageStartProxy, buildImage);
      Builder.AddEdge(buildImage, components);
      
      Builder.AddEdge(buildImage, Builder.End);
      Builder.AddEdge(components, Builder.End);
    }
  }
}
