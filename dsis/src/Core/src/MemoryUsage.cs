using System;
using System.Management;
using EugenePetrenko.Shared.Core.Ioc.Api;
using log4net;

namespace DSIS.Core
{
  [ComponentImplementation]
  public class MemoryUsage : IMemoryUsage
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (MemoryUsage));

    public MemoryInfo GetMemoryUsage()
    {
      var heap = GC.GetTotalMemory(false);

      var actions = new Func<MemoryInfo>[]
                      {
                        () => ReadOperationSystemInfo(heap), 
                        () => ReadLogicalMemoryConfiguration(heap),
                        () => new MemoryInfo(heap)
                      };

      foreach (var action in actions)
      {
        try
        {
          return action();
        } catch (Exception e)
        {
          LOG.Error(e);
        }
      }

      throw new Exception("Failed to get MemoryInfo");
    }

    private static MemoryInfo ReadLogicalMemoryConfiguration(long heap)
    {
      var winQuery = new ObjectQuery("SELECT * FROM Win32_LogicalMemoryConfiguration");

      using (var searcher = new ManagementObjectSearcher(winQuery))
      {
        foreach (ManagementObject item in searcher.Get())
        {
          return new MemoryInfo(
            Parse(item["TotalPhysicalMemory"]),
            Parse(item["TotalVirtualMemory"]),
            heap);
        }        
        return new MemoryInfo(heap);
      }
    }

    private static long? Parse(object x)
    {
      if (x == null)
      {
        return null;
      }

      return long.Parse(x.ToString()) * 1024;
    }

    private static MemoryInfo ReadOperationSystemInfo(long heap)
    {
      var winQuery = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");

      using (var searcher = new ManagementObjectSearcher(winQuery))
      {
        foreach (ManagementObject item in searcher.Get())
        {
          return new MemoryInfo(
            Parse(item["MaxProcessMemorySize"]),
            Parse(item["TotalVirtualMemorySize"]),
            heap);
        }        
        return new MemoryInfo(heap);
      }
    }
  }
}