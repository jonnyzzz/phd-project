using System;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner.ImageEntropy
{
  internal class LoggingJVRMeasure<TCell> : JVRMeasure<TCell> 
    where TCell : ICellCoordinate
  {
    private readonly Logger myLogger;

    public int? MaxSteps { get; set; }
    public TimeSpan? ExecutionSpan { get; set; }
    private readonly DateTime myStartTime;
    private int myStep;

    public LoggingJVRMeasure(IReadonlyGraph<TCell> graph, IGraphStrongComponents<TCell> components, JVRMeasureOptions opts, Logger logger) : base(graph, components, opts)
    {
      myLogger = logger;
      myStartTime = DateTime.Now;
    }

    protected override bool CheckExitCondition(JVRExitCondition condition, double precision, double totalError, double qValue, double nodesChange, double edgesChange)
    {
      if (MaxSteps != null && myStep++ > MaxSteps)
      {
        myLogger.Write("Limit of {0} iterations exceeded", MaxSteps);
        return true;
      }

      if (ExecutionSpan != null && (DateTime.Now - myStartTime) > ExecutionSpan)
      {
        myLogger.Write("Timeout of {0} iterations exceeded", ExecutionSpan);
        return true;
      }

      if (myStep % 25 == 0)
      {
        myLogger.Write(String.Format("  {5} -> precision:{0}, totalError:{1}, q:{2}, nodesChange:{3}, edgesChange:{4}",
                                     precision, totalError, qValue, nodesChange, edgesChange, myStep));
      }

      var result = base.CheckExitCondition(condition, precision, totalError, qValue, nodesChange, edgesChange);
      if (result)
        myLogger.Write("Iterations completed in {0}ms", (DateTime.Now - myStartTime).TotalMilliseconds);
      return result;
    }
  }
}