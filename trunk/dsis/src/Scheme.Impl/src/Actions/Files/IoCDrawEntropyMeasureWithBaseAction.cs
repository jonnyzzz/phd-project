using System.Collections.Generic;
using DSIS.Core.Ioc;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  [ComponentImplementation]
  public class IoCDrawEntropyMeasureWithBaseAction : DrawEntropyMeasureWithBaseActionBase
  {
    private readonly WorkingFolderInfo myWorkingFolder;

    //TODO: Move to context level
    public int Width { get; set; } 
    public int Height { get; set; } 

    public IoCDrawEntropyMeasureWithBaseAction(WorkingFolderInfo workingFolder, IEnumerable<DrawEntropyMeasureActionBase> actions)
      : base(actions)
    {
      myWorkingFolder = workingFolder;
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      base.Apply<T,Q>(PatchContext(input), output);
    }

    private Context PatchContext(Context input)
    {
      var ctx = new Context();
      ctx.AddAll(input);
      FileKeys.WorkingFolderKey.Set(ctx, myWorkingFolder);
      ImageDimension.KEY.Set(ctx, new ImageDimension{Width = Width, Height = Height});
      return ctx;
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return base.Check<T,Q>(PatchContext(ctx));
    }
  }
}