using System;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner.imageEntropy
{
  internal class LoggingJVRMeasure<TCell> : JVRMeasure<TCell> 
    where TCell : ICellCoordinate
  {
    private readonly Logger myLogger;
    
    private readonly int? myMaxSteps;
    private readonly TimeSpan? myExecutionSpan;
    private readonly DateTime myStartTime;

    private int myStep;
    public LoggingJVRMeasure(ImageEntropyData parameters, IReadonlyGraph<TCell> graph, IGraphStrongComponents<TCell> components, JVRMeasureOptions opts, Logger logger) : base(graph, components, opts)
    {
      myLogger = logger;

      myMaxSteps = parameters.MeasureIterations;
      myExecutionSpan = parameters.MeasureTimeout;
      myStartTime = DateTime.Now;
    }

    protected override bool CheckExitCondition(JVRExitCondition condition, double precision, double totalError, double qValue, double nodesChange, double edgesChange)
    {
      if (myMaxSteps != null && myStep++ > myMaxSteps)
      {
        myLogger.Write("Limit of {0} iterations exceeded", myMaxSteps);
        return true;
      }

      if (myExecutionSpan != null && (DateTime.Now - myStartTime) > myExecutionSpan)
      {
        myLogger.Write("Timeout of {0} iterations exceeded", myExecutionSpan);
        return true;
      }

      if (myStep % 25 == 0)
      {
        myLogger.Write(String.Format("  {5} -> precision:{0}, totalError:{1}, q:{2}, nodesChange:{3}, edgesChange:{4}",
                                     precision, totalError, qValue, nodesChange, edgesChange, myStep));
      }

      return base.CheckExitCondition(condition, precision, totalError, qValue, nodesChange, edgesChange);
    }
  }
}