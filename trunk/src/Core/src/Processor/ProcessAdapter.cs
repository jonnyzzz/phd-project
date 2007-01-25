using DSIS.Core.Util;

namespace DSIS.Core.Processor
{
  public class ProcessAdapter : IProcess
  {
    private ProcessDelegate del;

    public ProcessAdapter(ProcessDelegate del)
    {
      this.del = del;
    }

    public void Execute(IProgressInfo info)
    {
      del(info);
    }

    public void Dispose()
    {
    }
  }
}