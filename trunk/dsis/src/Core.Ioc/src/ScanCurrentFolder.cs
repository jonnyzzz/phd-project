using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using log4net;

namespace DSIS.Core.Ioc
{
  public class ScanCurrentFolder 
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (ScanCurrentFolder));

    public ScanCurrentFolder(IComponentContainer container)
    {
      var list = new List<Assembly>();
      string home = Path.GetDirectoryName(new Uri(GetType().Assembly.CodeBase).LocalPath);
      foreach (var file in Directory.GetFiles(home, "*,dll"))
      {
        try
        {
          list.Add(Assembly.LoadFile(file));
        } catch (Exception e)
        {
          LOG.Error(string.Format("Failed to load assembly {0}. {1}", file, e.Message), e);
          continue;
        }
      }
      container.ScanAssemblies(list);
    }
  }
}