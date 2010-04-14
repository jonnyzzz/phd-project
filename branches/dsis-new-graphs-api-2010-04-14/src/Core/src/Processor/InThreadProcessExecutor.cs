using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public class InThreadProcessExecutor : IProcess
  {
    private readonly IConcurentProcess myProcess;

    public InThreadProcessExecutor(IConcurentProcess process)
    {
      myProcess = process;
    }

    public void Execute(IProgressInfo info)
    {
      foreach (IProcess process in myProcess.ConcurrentProcesses)
      {
        process.Execute(info);
      }
    }
  }
}