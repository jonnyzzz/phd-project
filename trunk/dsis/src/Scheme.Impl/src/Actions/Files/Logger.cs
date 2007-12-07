using System.IO;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class Logger
  {
    private readonly string myWriter;
    private static readonly Logger NULL_LOGGER = new Logger(null);

    public Logger(WorkingFolderInfo info)
    {
      if (info != null)
      {
        myWriter = info.CreateFileName("log.txt");
      }
      else
      {
        myWriter = null;
      }
    }

    public void Write(string text)
    {
      if (myWriter != null)
      {
        File.AppendAllText(myWriter, text +"\r\n");
      }
      System.Console.Out.WriteLine(text);
    }

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
      else
      {
        return NULL_LOGGER;
      }
    }
  }
}