using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;

namespace DSIS.UI.ComputationDialogs.Constraints
{
  [SIConstructionComponent]
  public class RepeatNodesCountTool : RepeatWhileControlBase
  {
    public RepeatNodesCountTool() : base("Repeat while there are less than", "nodes")
    {
      SetEditFieldWidth(60);
    }

    public override string SortName
    {
      get { return "2000"; }
    }

    protected override ISIComputationConstraint CreateConstraint(long count)
    {
      return new RepeatWhileNodesConstraint(count);
    }

    private class RepeatWhileNodesConstraint : IntegerCoordinateComponentConstraint
    {
      private readonly long myCount;

      public RepeatWhileNodesConstraint(long count)
      {
        myCount = count;
      }

      protected override bool CanContinue<T, Q>(T system, Context ctx)
      {
        var key = Keys.Graph<Q>();
        if (ctx.ContainsKey(key))
        {
          var components = key.Get(ctx);

          return components.NodesCount < myCount;
        }

        var key2 = Keys.CellsEnumerationKey<Q>();
        if (ctx.ContainsKey(key2))
        {
          var components = key2.Get(ctx);

          return components.Count < myCount;
        }

        return false;
      }
    }
  }
}