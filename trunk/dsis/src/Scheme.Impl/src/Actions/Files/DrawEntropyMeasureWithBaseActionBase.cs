using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawEntropyMeasureWithBaseActionBase : IntegerCoordinateSystemActionBase3
  {
    private readonly Dictionary<int, IAction> myActions;

    protected DrawEntropyMeasureWithBaseActionBase(IEnumerable<DrawEntropyMeasureActionBase> list)
    {
      myActions = new Dictionary<int, IAction>();
      foreach (var d in list)
      {
        myActions[d.SystemDimension] = d;
      }
    }


    protected override void Apply<T, Q>(Context input, Context output)
    {
      IAction action;
      if (!myActions.TryGetValue(Dimension, out action))
      {
        throw new ContextMissmatchException(
          new[]
            {
              new ContextMissmatch(Keys.SystemInfoKey, "Dimension does not supported", this)
            }, this, input);
      }
      output.AddAll(action.Apply(input));
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      IAction action;
      if (!myActions.TryGetValue(Dimension, out action))
      {
        return new[] { new ContextSystemDimensionMissmatch(Keys.SystemInfoKey, "Dimension does not supported", this) };
      }
      //todo:dangerous cast
      return new List<ContextMissmatch>(action.Compatible(ctx)).ConvertAll(x => (ContextMissmatchCheck) x);
    }


    private class ContextSystemDimensionMissmatch : ContextMissmatchCheck
    {
      public ContextSystemDimensionMissmatch(IKey key, string message, IAction action) : base(key, message, action)
      {
      }

      public override bool Check(Context ctx)
      {
        return false;
      }
    }
  }
}