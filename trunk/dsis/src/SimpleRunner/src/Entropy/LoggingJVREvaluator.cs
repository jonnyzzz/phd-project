using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner.Entropy
{
  public class LoggingJVREvaluator<Q> : JVREvaluator<Q>
    where Q : ICellCoordinate
  {
    private readonly Logger myLogger;

    public LoggingJVREvaluator(JVRMeasureOptions opts, Logger logger)
      : base(opts)
    {
      myLogger = logger;
    }

    protected override JVRMeasure<Q> CreateMeasure(IReadonlyGraph<Q> graph, IGraphStrongComponents<Q> comps)
    {
      return new LoggingJVREvaluatorImpl<Q>(graph, comps, myOpts, myLogger);
    }
  }
}