using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl;

namespace DSIS.UI.ComputationDialogs.Constraints
{
  [SIConstructionComponent]
  public class RepeatWhileComponentsCount : RepeatWhileControlBase
  {
    public RepeatWhileComponentsCount() : base("Repeat while there are less than", "components")
    {
    }

    public override string SortName
    {
      get { return "3000"; }
    }

    protected override ISIComputationConstraint CreateConstraint(long count)
    {
      return new RepeatWhileComponentConstraint(count);
    }

    private class RepeatWhileComponentConstraint : IntegerCoordinateComponentConstraint
    {
      private readonly long myCount;

      public RepeatWhileComponentConstraint(long count)
      {
        myCount = count;
      }

      protected override bool CanContinue<T, Q>(T system, Context ctx)
      {
        if (!ctx.ContainsKey(Keys.GetGraphComponents<Q>()))
          return false;
        var components = Keys.GetGraphComponents<Q>().Get(ctx);

        return components.ComponentCount < myCount;
      }
    }
  }
}