using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpInvocationCountAction : ActionBase
  {
    private int myCount = 0;
    private readonly string myMessage;

    public DumpInvocationCountAction(string message)
    {
      myMessage = message;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, Create(FileKeys.LoggerKey));
    }

    protected override void Apply(Context ctx, Context result)
    {
      Logger.Instance(ctx).Write("Counter {0}. {1}", myMessage, ++myCount);
    }
  }
}