using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Exec;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawEntropyMeasureWithBaseAction : IntegerCoordinateSystemActionBase2
  {
    private readonly Dictionary<int, ISimpleAction> myActions = new Dictionary<int, ISimpleAction>
                                                                  {
                                                                    {1, new DrawEntropyMeasure2dWithBaseAction()},
                                                                    {2, new DrawEntropyMeasure3dWithBaseAction()},                                                              
                                                                  };

    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      ISimpleAction action;
      if (!myActions.TryGetValue(system.Dimension, out action))
      {
        throw new ContextMissmatchException(
          new[] {new ContextMissmatch(Keys.SystemInfoKey, "Dimension does not supported", this)}, this,
          input);
      }
      output.AddAll(action.Apply(input));
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      ISimpleAction action;
      if (!myActions.TryGetValue(system.Dimension, out action))
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