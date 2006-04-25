using System.Diagnostics;
using System.Threading;

namespace EugenePetrenko.Gui2.ExternalResource.ProcessRunner
{
  /// <summary>
  /// Summary description for Process.
  /// </summary>
  /// 
  public delegate void ProcessFinished();

  public class SmartProcess
  {
    private Process process;

    public SmartProcess(Process process)
    {
      this.process = process;
    }

    public void Start()
    {
      Thread thread = new Thread(new ThreadStart(ProcessCheckRunner));
      thread.Priority = ThreadPriority.Lowest;
      thread.Start();
    }

    public event ProcessFinished Finished;

    private void ProcessCheckRunner()
    {
      process.Start();
      if (Finished == null) return;

      while (true)
      {
        Thread.Sleep(100);
        if (process.HasExited)
        {
          Finished();
          break;
        }
      }
    }
  }
}