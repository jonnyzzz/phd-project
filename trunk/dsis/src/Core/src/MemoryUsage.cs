using System;
using System.Management;
using DSIS.Core.Ioc;

namespace DSIS.Core
{
  [ComponentImplementation]
  public class MemoryUsage : IMemoryUsage
  {
    public MemoryInfo GetMemoryUsage()
    {
      var winQuery = new ObjectQuery("SELECT * FROM Win32_LogicalMemoryConfiguration");

      var searcher = new ManagementObjectSearcher(winQuery);

      var heap = GC.GetTotalMemory(false);

      foreach (ManagementObject item in searcher.Get())
      {
        Func<object, long> parse = x => long.Parse(x.ToString());
        return new MemoryInfo(
          parse(item["TotalPhysicalMemory"]), 
          parse(item["TotalVirtualMemory"]), 
          parse(item["AvailableVirtualMemory"]), 
          heap);
      }

      return new MemoryInfo(heap);
    }
  }
}