using System.Collections.Generic;

namespace DSIS.Core.Processor
{
  public interface IConcurentProcess
  {
    IEnumerable<IProcess> ConcurrentProcesses { get; }
  }
}