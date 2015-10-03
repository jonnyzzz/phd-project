using System;
using System.Collections;
using System.IO;
using EugenePetrenko.Gui2.ExternalResource.Core;

namespace EugenePetrenko.Gui2.ExternalResource.FileResources
{
  /// <summary>
  /// Summary description for TempFileAllocator.
  /// </summary>
  public class TempFileAllocator : IDisposable
  {
    private ArrayList files = new ArrayList();
    private bool keepFiles;

    public TempFileAllocator(bool keepFiles)
    {
      this.keepFiles = keepFiles;
    }

    public void Dispose()
    {
      if (!keepFiles)
      {
        foreach (string file in files)
        {
          try
          {
            File.Delete(file);
          }
          catch (Exception)
          {
          }
        }
      }
    }

    private static int num = 0;

    public string CreateFile()
    {
      return CreateFile(ResourceManager.Instance.TemporaryPath);
    }

    private string CreateFileName()
    {
      return CreateFileName("temp");
    }

    public string CreateFileName(string ext)
    {
      string file = string.Format("{0}.{1}.{2}-{3}.{4}.{5}.{6}.{7}.{8}",
                                  DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year,
                                  DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond,
                                  num++, ext);

      while (File.Exists(file)) file += "_";

      return /*ResourceManager.Instance.SimplyfyPath(*/ file;
    }

    public string CreateFile(string path)
    {
      string file = string.Format("{1}/{0}",
                                  CreateFileName(),
                                  path
        );

      while (File.Exists(file)) file += "_";
      files.Add(file);

      return ResourceManager.Instance.SimplyfyPath(file);
    }

    public string SaveToTempFile(string data)
    {
      string file = CreateFile();
      TextWriter writer = File.CreateText(file);
      writer.WriteLine(data);
      writer.Close();
      return file;
    }
  }
}