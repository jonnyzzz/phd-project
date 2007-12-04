using System.Collections.Generic;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpGraphComponentsInfoAction : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      return new ContextMissmatchCheck[] {
                                           Create(Keys.GraphComponents<Q>())
                                         };
    }

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      IGraphStrongComponents<Q> gr = Keys.GraphComponents<Q>().Get(input);

      System.Console.Out.WriteLine("Components: {0}", gr.ComponentCount);
      System.Console.Out.Write("Component's Nodes: ");
      foreach (IStrongComponentInfo info in gr.Components)
      {
        System.Console.Out.Write("{0}, ", info.NodesCount);        
      }
      System.Console.Out.WriteLine();
    }
  }
}