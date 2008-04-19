using System.Collections.Generic;
using System.Text;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

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

      StringBuilder sb = new StringBuilder();
      sb.AppendFormat("Components: {0}", gr.ComponentCount).AppendLine();
      sb.Append("Component's Nodes: ");
      foreach (IStrongComponentInfo info in gr.Components)
      {
        sb.AppendFormat("{0}, ", info.NodesCount);        
      }
      Logger.Instance(input).Write(sb.ToString());
    }
  }
}