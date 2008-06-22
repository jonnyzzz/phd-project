using System.Collections.Generic;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class LoopStepWorkingFolderAction : PrefixWorkingFolderAction
  {
    private readonly string myTemplate;
    private readonly ILoopAction myLoopAction;

    public LoopStepWorkingFolderAction(ILoopAction action, string template)
    {
      myLoopAction = action;
      myTemplate = template;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, base.Compatible(ctx), Create(myLoopAction.Key));
    }

    protected override string Prefix(Context ctx)
    {
      return string.Format(myTemplate, myLoopAction.Key.Get(ctx).Index);
    }
  } 
}