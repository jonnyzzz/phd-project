namespace DSIS.Core
{
  public class MemoryInfo
  {
    public readonly long? TotalPhysicalMemory;
    public readonly long? TotalVirtualMemory;
    public readonly long? AvailableVirtualMemory;
    public readonly long HeapMemory;

    public MemoryInfo(long totalPhysicalMemory, long totalVirtualMemory, long totalAvailableMemory, long heapMemory)
    {
      TotalPhysicalMemory = totalPhysicalMemory;
      TotalVirtualMemory = totalVirtualMemory;
      AvailableVirtualMemory = totalAvailableMemory;
      HeapMemory = heapMemory;
    }

    public MemoryInfo(long heapMemory)
    {
      HeapMemory = heapMemory;
    }
  }
}