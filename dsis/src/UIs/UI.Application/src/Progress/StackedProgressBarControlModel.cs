using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Util;
using DSIS.Utils;
using log4net;

namespace DSIS.UI.Application.Progress
{
  public class StackedProgressBarControlModel : IProgressBarControlModel
  {
    private static readonly ILog LOG = LogManager.GetLogger(typeof (StackedProgressBarControlModel));

    private readonly List<Qookie> myProgresses = new List<Qookie>();
    
    public void UnderProgress(string operation, Action<IProgressInfo> action, Action interrupt)
    {
      var simpleProgress = new SimpleProgressImpl { Maximum = 1000 };      
      var userProgress = simpleProgress.SubProgress(simpleProgress.Maximum);
      userProgress.Maximum = 1;
      userProgress.Text = operation;

      var qookie = new Qookie(simpleProgress, interrupt);
      lock (myProgresses)
      {
        myProgresses.Add(qookie);
      }

      try
      {
        action(userProgress);
      } catch (Exception e)
      {
        LOG.Warn("Failed to perform " + operation, e);
      }


      lock(myProgresses)
      {
        myProgresses.Remove(qookie);
      }
    }

    private class Qookie
    {
      private readonly SimpleProgressImpl myProgress;
      private readonly Action myTerminate;

      public Qookie(SimpleProgressImpl progress, Action terminate)
      {
        myProgress = progress;
        myTerminate = terminate;
      }

      public IProgressInfo ProgressInfo { get { return myProgress; } }

      public int Value
      {
        get { return (int)myProgress.Value; }
      }

      public void Terminate()
      {
        myProgress.IsInterrupted = true;
        try
        {
          myTerminate();
        } catch (Exception e)
        {
          LOG.Warn("Failed to terminate action under progress", e);
        }
      }
    }

    private Qookie CurrentAction
    {
      get 
      {
        lock (myProgresses)
        {
          return myProgresses.FirstOrDefault();
        }
      }
    }

    public bool Disabled
    {
      get { return CurrentAction == null; }
    }

    public int Value
    {
      get { return CurrentAction.Safe(0, x => x.Value); }
    }

    public int Maximum
    {
      get { return CurrentAction.Safe(0, x => (int)x.ProgressInfo.Maximum); }
    }

    public string Text
    {
      get { return CurrentAction.Safe("", x => x.ProgressInfo.Text ?? ""); }
    }

    public void Interrupt()
    {
      Qookie[] imp;
      lock (myProgresses)
      {
        imp = myProgresses.ToArray();
      }
      foreach (var i in imp)
      {
        i.Terminate();
      }
    }
  }
}