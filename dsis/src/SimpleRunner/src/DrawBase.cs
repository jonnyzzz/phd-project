using System;
using System.IO;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public abstract class DrawBase
  {
    private string myTitle;
    private string myPath;

    public string Title
    {
      get { return myTitle; }
      set { myTitle = value; }
    }

    public Pair<string, Action<string>> FormatPath
    {
      get { return new Pair<string, Action<string>>("{0}", delegate(string path) { myPath = path; }); }
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

    protected string CreateFileName(string ext)
    {
      string path = MakeFileName(ext);
      if (!File.Exists(path))
      {
        return path;
      }
      
      for(int c = 0; ; c++)
      {
        path = MakeFileName(c + ext);
        if (!File.Exists(path))
          return path;
      }
    }

    public abstract string DrawImage(string suffix);
  }
}