using DSIS.LineIterator;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Scheme.Impl.Actions.Line;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpLineAction : LineBaseAction
  {
    protected override void Apply(ILine line, Context ctx, Context result)
    {
      Logger.Instance(ctx).Write("Points: {0} Length:{1:R}", line.Count, line.Length);
    }
  }  
}