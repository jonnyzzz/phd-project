using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpSubdivisionAction : IntegerCoordinateSystemActionBase2
  {
    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      var logger = Logger.Instance(input);
      logger.Write("System: ");
      logger.Write(" Subd = " + system.Subdivision.JoinString(", "));
      logger.Write(" Eps = " + system.CellSize.JoinString(", "));
    }
  }
}