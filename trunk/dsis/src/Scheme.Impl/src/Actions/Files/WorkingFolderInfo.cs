using System.IO;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class WorkingFolderInfo
  {
    private readonly string myPath;

    public WorkingFolderInfo(string path)
    {
      myPath = path;
    }

    private static string ToSafePath(string s)
    {
      return s.Replace("`", "_").Replace(",", ".").Replace(" ", "_");
    }

    private string MakeFileName(string ext)
    {
      string bs = myPath + ToSafePath("/" + GetType().Name + "/image_");

      string path = bs + ext;
      string dir = Path.GetDirectoryName(path);
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);
      return path;
    }

    public string CreateFileName(string ext)
    {
      string path = MakeFileName(ext);
      if (!File.Exists(path))
      {
        return path;
      }

      for (int c = 0; ; c++)
      {
        path = MakeFileName(c + ext);
        if (!File.Exists(path))
          return path;
      }
    }

    public string Path
    {
      get { return myPath; }
    }
  }
}