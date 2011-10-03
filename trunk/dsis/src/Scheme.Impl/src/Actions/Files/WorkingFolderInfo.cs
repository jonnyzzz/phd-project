using System;
using System.IO;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public interface IWorkingFolderInfo : ITempFileFactory
  {
    
  }

  public class WorkingFolderInfo : IWorkingFolderInfo
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
      const string chars = @"'`!$%&*,:"" =+";
      return chars.ToCharArray().FoldLeft(s, (c, ss) => ss.Replace(c.ToString(), "_"));
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

    public string NewFile(string prefix)
    {
      return CreateFileName(prefix);
    }

    public ITempFileFactory ApplyPrefix(string before, string after)
    {
      return new TempFileFactoryImpl(this, x => before + x + after);
    }

    private class TempFileFactoryImpl : ITempFileFactory
    {
      private readonly WorkingFolderInfo myInfo;
      private readonly Func<string, string> myFormat;

      public TempFileFactoryImpl(WorkingFolderInfo info, Func<string, string> format)
      {
        myInfo = info;
        myFormat = format;
      }

      public string NewFile(string prefix)
      {
        return myInfo.CreateFileName(myFormat(prefix));
      }

      public ITempFileFactory ApplyPrefix(string before, string after)
      {
        return new TempFileFactoryImpl(myInfo, x => before + x + after);
      }
    }
  }
}