using DSIS.Scheme.Actions;
using DSIS.Scheme.Impl.Actions.Performance;

namespace DSIS.Scheme.Impl.Actions.Agregated
{
  public class SymbolicImageConstructionStep : AgregateAction
  {
    public SymbolicImageConstructionStep()
    {
      IAction merge = new MergeComponetsAction();
      //todo:Crap!!! Do not use time checker here!
      IAction buildImage = new RecordTimeSlotAction(new BuildSymbolicImageAction(), "BuildSymbolicImage");

      IAction components = new ChainRecurrenctSimbolicImageAction();
      IAction buildImageStartProxy = new ProxyAction();

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
