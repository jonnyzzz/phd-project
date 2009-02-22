using System;
using System.Drawing;
using DSIS.Scheme.Ctx;
using DSIS.Utils;
using log4net;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class IoCDrawHelper<T> : IIocDrawHelper
    where T : IAction
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (IoCDrawHelper<T>));

    private readonly T myAction;

    protected IoCDrawHelper(T action)
    {
      myAction = action;
    }

    public string DrawImage(Context context, Size sz)
    {
      var ctx = context.Clone();
      ImageDimension.KEY.Set(ctx, new ImageDimension {Width = sz.Width, Height = sz.Height});

      try
      {
        if (myAction.Compatible(ctx).IsEmpty())
        {
          var result = myAction.Apply(ctx);
          if (result.ContainsKey(FileKeys.ImageKey))
          {
            return FileKeys.ImageKey.Get(result).Path;
          }
        }
      }
      catch (Exception e)
      {
        LOG.Error("Failed to draw image. " + e.Message, e);
      }
      return null;
    }
  }
}