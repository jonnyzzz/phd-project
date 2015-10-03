using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DSIS.LibraryVersionFixer;
using log4net;

namespace DSIS.LibraryVersionFixer
{
  public class VersionFixer : IDisposable
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (VersionFixer));

    private readonly Dictionary<String, String> myMap = new Dictionary<string, string>();
    private readonly Dictionary<String, Assembly> myImpl = new Dictionary<string, Assembly>();

    public VersionFixer(IList filesToTrack)
    {      
      if (LOG.IsDebugEnabled)
      {
        LOG.Debug("Assembly version fix started:");
        foreach (object files in filesToTrack)
        {
          LOG.Debug(files);
        }
      }

      foreach (string file in filesToTrack)
      {
        try
        {
          string path = Path.Combine(Path.GetDirectoryName(new Uri(GetType().Assembly.CodeBase).LocalPath), file);
          AssemblyName name = AssemblyName.GetAssemblyName(path);
          myMap[name.FullName] = path;
        }
        catch (Exception e)
        {
          LOG.Warn(e.Message, e);
        }
      }

      AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
      AppDomain.CurrentDomain.AssemblyLoad += AssemblyLoad;
    }

    private void AssemblyLoad(object sender, AssemblyLoadEventArgs args)
    {
      myImpl[args.LoadedAssembly.GetName().FullName] = args.LoadedAssembly;
    }

    private Assembly AssemblyResolve(object sender, ResolveEventArgs args)
    {
      LOG.DebugFormat("Resolve call for {0}", args.Name);

      string name = args.Name;
      Assembly assebmly;
      if (myImpl.TryGetValue(name, out assebmly))
      {
        LOG.DebugFormat("From assemblies cache {0}", assebmly.GetName().FullName);
        return assebmly;
      }

      string path;
      if (myMap.TryGetValue(name, out path))
      {
        LOG.DebugFormat("From path {0}", path);
        try
        {
          return Assembly.LoadFile(path);
        }
        catch (Exception e)
        {
          LOG.Error(e.Message, e);
        }
      }
      LOG.Debug("None returned");
      return null;
    }

    public void Dispose()
    {
      AppDomain.CurrentDomain.AssemblyResolve -= AssemblyResolve;
      AppDomain.CurrentDomain.AssemblyLoad += AssemblyLoad;
    }
  }
}