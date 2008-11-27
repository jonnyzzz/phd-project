using System;
using System.Collections.Generic;
using System.IO;
using log4net;

namespace DSIS.Spring.Util
{
  public class TempFileManager : IDisposable
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (TempFileManager));

    private readonly List<string> myTempFiles = new List<string>();

    public string GetTempFile()
    {
      return Path.GetTempFileName();
    }

    public void Dispose()
    {
      foreach (string file in myTempFiles)
      {
        try
        {
          File.Delete(file);
        } catch (Exception e)
        {
          LOG.Error("Failed to delete file", e);
        }
      }
    }
  }
}