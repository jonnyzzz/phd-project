using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class Logger 
  {
    public abstract void Write(string text);

    public void Write(string fmt, params object[] data)
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