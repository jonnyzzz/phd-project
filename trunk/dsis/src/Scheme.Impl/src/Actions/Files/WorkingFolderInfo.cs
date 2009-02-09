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

    public WorkingFolderInfo Prefix(string pref)
    {
      return new WorkingFolderInfo(System.IO.Path.Combine(myPath, ToSafePath(pref)));
    }

    private static string ToSafePath(string s)
    {      
      return s.Replace("`", "_").Replace(",", ".").Replace(" ", "_").Replace("=", "_").Replace(":","_").Replace("'", "_");
    }

    private string MakeFileName(string ext)
    {
      string bs = myPath + ToSafePath("/");

      string path = bs + ext;
      string dir = System.IO.Path.GetDirectoryName(path);
      if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);
      return path;
    }

    

    public string CreateFileName(string ext)
    {
      //todo: Escape
      return CreateFileNameFromTemplate(System.IO.Path.GetFileNameWithoutExtension(ext) + "-{0}." + System.IO.Path.GetExtension(ext));
    }

    public string CreateFileNameFromTemplate(string template)
    {
      string path = MakeFileName(string.Format(template, string.Empty));
      if (!File.Exists(path))
      {
        return System.IO.Path.GetFullPath(path);
      }

      for (int c = 0; ; c++)
      {
        path = MakeFileName(string.Format(template, c));
        if (!File.Exists(path))
          return System.IO.Path.GetFullPath(path);
      }
    }

    public string Path
    {
      get { return myPath; }
    }
  }
}