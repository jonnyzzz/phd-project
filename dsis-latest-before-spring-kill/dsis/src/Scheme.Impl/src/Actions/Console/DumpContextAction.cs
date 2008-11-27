using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Console
{
  public class DumpContextAction : ActionBase
  {
    private readonly string myTitle;

    public DumpContextAction(string title)
    {
      myTitle = title;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      Logger.Instance(ctx).Write(myTitle + ": " + ctx);
    }
  }

  public class DumpContextProxy : ActionBase
  {
    private readonly string myTitle;
    private readonly IAction myAction;

    public DumpContextProxy(string title, IAction action)
    {
      myTitle = title;
      myAction = action;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      Logger.Instance(ctx).Write(myTitle + ": " + ctx);

      result.AddAll(((IAction)myAction).Apply(ctx));
    }
  }
}