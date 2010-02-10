using System.Collections.Generic;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Actions
{
  public class CopyContextKeysAction : ActionBase
  {
    private readonly ICollection<IKey> myAcceptKeys;

    public CopyContextKeysAction(params IKey[] acceptKeys)
    {
      myAcceptKeys = acceptKeys;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      //todo:
      return EmptyArray<ContextMissmatch>.Instance;
    }

    protected override void Apply(Context ctx, Context result)
    {
      foreach (IKey key in myAcceptKeys)
      {
        key.Copy(ctx, result);
      }
    }
  }
}