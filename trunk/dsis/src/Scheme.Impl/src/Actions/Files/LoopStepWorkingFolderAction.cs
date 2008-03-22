using System.Collections.Generic;
using DSIS.Scheme.Actions;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class LoopStepWorkingFolderAction : PrefixWorkingFolderAction
  {
    private readonly string myTemplate;

    public LoopStepWorkingFolderAction(string template)
    {
      myTemplate = template;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx, base.Compatible(ctx), Create(LoopAction.LoopIndexKey));
    }

    protected override string Prefix(Context ctx)
    {
      return string.Format(myTemplate, LoopAction.LoopIndexKey.Get(ctx).Index);
    }
  } 
}