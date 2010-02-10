using System.Collections.Generic;
using System.Text;
using DSIS.Graph;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpGraphComponentsInfoAction : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return new[] {Create(Keys.GraphComponents<Q>())};
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      IGraphStrongComponents<Q> gr = Keys.GraphComponents<Q>().Get(input);

      var sb = new StringBuilder();
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