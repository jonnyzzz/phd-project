using System.IO;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class FileLogger : Logger
  {
    private readonly string myWriter;

    public FileLogger(WorkingFolderInfo info)
    {
      if (info != null)
      {
        myWriter = info.CreateFileName("log.txt");
        Write("Logger is set to {0}", myWriter);
      }
      else
      {
        myWriter = null;
      }
    }

    public override void Write(string text)
    {
      if (myWriter != null)
      {
        File.AppendAllText(myWriter, text +"\r\n");
      }
    }
  }
}