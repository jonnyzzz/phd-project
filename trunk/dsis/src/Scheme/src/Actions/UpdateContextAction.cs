using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Actions
{
  public class UpdateContextAction : ActionBase
  {
    public delegate void WithContext(Context input, Context cx);

    private readonly WithContext myWith;


    public UpdateContextAction(WithContext with)
    {
      myWith = with;
    }


    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      myWith(ctx, result);
    }
  }
}