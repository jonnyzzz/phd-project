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

    #region IProcess Members

    public void Execute(IProgressInfo info)
    {
      del(info);
    }

    #endregion

    public void Dispose()
    {
    }
  }
}