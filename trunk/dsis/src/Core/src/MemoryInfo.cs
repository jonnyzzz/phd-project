namespace DSIS.Core
{
  public class MemoryInfo
  {
    public readonly long? TotalPhysicalMemory;
    public readonly long? TotalVirtualMemory;
    public readonly long HeapMemory;

    public MemoryInfo(long? totalPhysicalMemory, long? totalVirtualMemory, long heapMemory)
    {
      TotalPhysicalMemory = totalPhysicalMemory;
      TotalVirtualMemory = totalVirtualMemory;
      HeapMemory = heapMemory;
    }

    public MemoryInfo(long heapMemory)
    {
      HeapMemory = heapMemory;
    }
  }
}