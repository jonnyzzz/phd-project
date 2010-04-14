using System;
using System.Collections.Generic;
using System.Threading;
using DSIS.Core.Util;
using log4net;

namespace DSIS.UI.Application.Progress
{
  public class SimpleActionExecution : IActionExecution
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof(SimpleActionExecution));
    private readonly List<Thread> myWorkerThreads = new List<Thread>();

    public void ExecuteAsync(string name, Action<IProgressInfo> action)
    {
      var impl = new ProgressImpl { Maximum = 1, Text = name };

      var thread = new Thread(delegate()
                                {
                                  try
                                  {
                                    action(impl);
                                  }
                                  catch (Exception e)
                                  {
                                    LOG.Error("Action " + name + " failed. " + e.Message, e);
                                  }
                                  finally
                                  {
                                    lock (myWorkerThreads) myWorkerThreads.Add(Thread.CurrentThread);
                                  }
                                });
      thread.Name = "Action " + name;
      thread.IsBackground = false;

      lock (myWorkerThreads) myWorkerThreads.Add(thread);

      thread.Start();
    }
  }
}