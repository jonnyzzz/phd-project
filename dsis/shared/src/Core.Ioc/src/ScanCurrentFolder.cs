using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using log4net;

namespace EugenePetrenko.Shared.Core.Ioc
{
  public class ScanCurrentFolder
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (ScanCurrentFolder));

    public ScanCurrentFolder(IComponentContainer container)
    {
      var list = new HashSet<Assembly>();
      string home = Path.GetDirectoryName(new Uri(GetType().Assembly.CodeBase).LocalPath);
      foreach (var file in Directory.GetFiles(home, "*.dll"))
      {
        if (!container.Filter.Accept(file))
        {
          LOG.InfoFormat("File {0} is skipped.", file);
          continue;
        }
        try
        {
          AssemblyName name = AssemblyName.GetAssemblyName(file);
          Assembly assembly = Assembly.Load(name);
          list.Add(assembly);
        }
        catch (Exception e)
        {
          LOG.Error(string.Format("Failed to load assembly {0}. {1}", file, e.Message), e);
          continue;
        }
      }
      container.ScanAssemblies(list);
    }
  }
}