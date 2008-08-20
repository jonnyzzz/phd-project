using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawEntropyMeasureWithBaseAction : IntegerCoordinateSystemActionBase3
  {
    private readonly Dictionary<int, IAction> myActions = new Dictionary<int, IAction>
                                                                  {
                                                                    {1, new DrawEntropyMeasure2dWithBaseAction()},
                                                                    {2, new DrawEntropyMeasure3dWithBaseAction()},                                                              
                                                                  };

    protected override void Apply<T, Q>(Context input, Context output)
    {
      IAction action;
      if (!myActions.TryGetValue(Dimension, out action))
      {
        throw new ContextMissmatchException(
          new[] {new ContextMissmatch(Keys.SystemInfoKey, "Dimension does not supported", this)}, this,
          input);
      }
      output.AddAll(action.Apply(input));
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      IAction action;
      if (!myActions.TryGetValue(Dimension, out action))
      {
        throw new ContextMissmatchException(
          new[] { new ContextMissmatch(Keys.SystemInfoKey, "Dimension does not supported", this) }, this,
          ctx);
      }
      //todo:dangerous cast
      return new List<ContextMissmatch>(action.Compatible(ctx)).ConvertAll(x => (ContextMissmatchCheck) x);
    }
  }
}