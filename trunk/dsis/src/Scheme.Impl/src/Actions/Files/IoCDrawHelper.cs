using System.Drawing;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class IoCDrawHelper<T> : IIocDrawHelper 
    where T : IAction
  {
    private readonly T myAction;

    protected IoCDrawHelper(T action)
    {
      myAction = action;
    }

    public string DrawImage(Context context, Size sz)
    {
      var ctx = context.Clone();
      ImageDimension.KEY.Set(ctx, new ImageDimension { Width = sz.Width, Height = sz.Height });

      string file = null;
      if (myAction.Compatible(ctx).IsEmpty())
      {
        var result = myAction.Apply(ctx);
        if (result.ContainsKey(FileKeys.ImageKey))
        {
          file = FileKeys.ImageKey.Get(result).Path;
        }
      }
      return file;
    }
  }
}