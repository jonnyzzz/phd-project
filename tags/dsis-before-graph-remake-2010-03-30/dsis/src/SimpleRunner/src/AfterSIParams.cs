using DSIS.Scheme;
using DSIS.Scheme.Exec;

namespace DSIS.SimpleRunner
{
  public class AfterSIParams<T> 
    where T : ComputationData, ICloneable<T>
  {
    private readonly IActionEdgesBuilder mySiConstructionAction;
    private readonly IAction mySystem;
    private readonly IAction myWorkingFolder;
    private readonly IAction myLogger;
    private readonly T myComputationData;
    private readonly bool myIsLast;

    public AfterSIParams(IActionEdgesBuilder siConstructionAction, IAction system, IAction workingFolder, IAction logger, T computationData, bool isLast)
    {
      mySiConstructionAction = siConstructionAction;
      mySystem = system;
      myWorkingFolder = workingFolder;
      myLogger = logger;
      myComputationData = computationData;
      myIsLast = isLast;
    }

    public IActionEdgesBuilder SiConstructionAction
    {
      get { return mySiConstructionAction; }
    }

    public IAction System
    {
      get { return mySystem; }
    }

    public IAction WorkingFolder
    {
      get { return myWorkingFolder; }
    }

    public IAction Logger
    {
      get { return myLogger; }
    }

    public T ComputationData
    {
      get { return myComputationData; }
    }

    public bool IsLast
    {
      get { return myIsLast; }
    }
  }
}