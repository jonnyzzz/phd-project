using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class Logger : ILogger
  {
    public abstract void Write(string text);

    public virtual void Write(string fmt, params object[] data)
    {
      Write(string.Format(fmt, data));
    }

    public static Logger Instance(Context ctx)
    {
      if (ctx.ContainsKey(FileKeys.LoggerKey))
      {
        return FileKeys.LoggerKey.Get(ctx);
      }
      return new ConsoleLogger();
    }
  }
}