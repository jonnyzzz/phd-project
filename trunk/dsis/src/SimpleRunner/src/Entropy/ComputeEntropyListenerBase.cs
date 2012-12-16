using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Entropy;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.IntegerCoordinates;
using DSIS.SimpleRunner.Builder;

namespace DSIS.SimpleRunner.Entropy
{
  public abstract class ComputeEntropyListenerBase<T,Q> : ProvideExternalListenerBase<T,Q, IComputeEntropyListener<Q>>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    protected abstract string Suffix { get; }

    public ComputeEventType ComputeEvent = ComputeEventType.OnFinish;

    public enum ComputeEventType
    {
      OnFinish,
      OnEveryStep
    }

    public override void ComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                             AbstractImageBuilderContext<Q> cx)
    {
      if (ComputeEvent == ComputeEventType.OnFinish)
        DoEvaluate(graph, comps);
    }

    public override void OnStepFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                        AbstractImageBuilderContext<Q> cx)
    {
      if (ComputeEvent == ComputeEventType.OnEveryStep)
        DoEvaluate(graph, comps);
    }

    private void DoEvaluate(IGraph<Q> graph, IGraphStrongComponents<Q> comps)
    {
      OnComputeEntropyStarted();

      Controller controller = new NoProjectController(graph, comps, this);

      IEntropyEvaluator<Q> evaluator = GetLoopEntropyEvaluator();
      evaluator.ComputeEntropy(controller, NullProgressInfo.INSTANCE);

      OnComputeEntropyFinished(controller.Results);
    }

    protected abstract IEntropyEvaluator<Q> GetLoopEntropyEvaluator();

    private void OnComputeEntropyFinished(double[] entropy)
    {
      FireListeners(listener => listener.OnComputeEntropyFinished(Suffix, entropy));

    }

    private void OnComputeEntropyStarted()
    {
      FireListeners(listener => listener.OnComputeEntropyStarted());
    }

    private class Controller : IEntropyEvaluatorController<Q>
    {
      private readonly ComputeEntropyListenerBase<T, Q> myHost;
      private readonly IGraph<Q> myGraph;
      private readonly IGraphStrongComponents<Q> myComponents;
      private readonly List<double> myResults = new List<double>();
      private ICellCoordinateSystem<Q> mySystem;

      public Controller(IGraph<Q> graph, IGraphStrongComponents<Q> components, ComputeEntropyListenerBase<T, Q> host)
      {
        myGraph = graph;
        myHost = host;
        myComponents = components;
      }

      public double[] Results
      {
        get { return myResults.ToArray(); }
      }

      public IGraph<Q> Graph
      {
        get { return myGraph; }
      }

      public IGraphStrongComponents<Q> Components
      {
        get { return myComponents; }
      }

      public virtual bool SubdivideNext(ICellCoordinateSystem<Q> system)
      {
        return system.Subdivision[0] >= 10;
      }

      public void SetCoordinateSystem(ICellCoordinateSystem<Q> system)
      {
        mySystem = system;
      }

      public virtual void OnResult<P>(double result, IDictionary<Q, double> measure, IDictionary<P, double> edges) where P : PairBase<Q>
      {        
        myResults.Add(result);
        myHost.FireListeners(obj => obj.OnComputeEntropyStep(result, measure, edges, mySystem));
      }
    }
  
    private class NoProjectController : Controller
    {
      private bool myHasResult;

      public NoProjectController(IGraph<Q> graph, IGraphStrongComponents<Q> components, ComputeEntropyListenerBase<T, Q> host) : base(graph, components, host)
      {
      }

      public override bool SubdivideNext(ICellCoordinateSystem<Q> system)
      {
        return !myHasResult;
      }

      public override void OnResult<P>(double result, IDictionary<Q, double> measure, IDictionary<P, double> edges)
      {
        myHasResult = true;
        base.OnResult(result, measure, edges);
      }
    }
  }
}