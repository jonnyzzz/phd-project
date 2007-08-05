using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.Util;
using DSIS.Graph;
using DSIS.Graph.Entropy;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public class ComputeEntropyListener<T,Q> : ProvideExternalListenerBase<T,Q, IComputeEntropyListener<Q>>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    public override void OnStepFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                        AbstractImageBuilderContext<Q> cx)
    {
      OnComputeEntropyStarted();

      Controller controller = new Controller(graph, comps, this);

      IEntropyEvaluator<Q> evaluator = EntropyEvaluator<Q>.GetLoopEntropyEvaluator();
      evaluator.ComputeEntropy(controller, NullProgressInfo.INSTANCE);

      OnComputeEntropyFinished(controller.Results); 
    }

    private void OnComputeEntropyFinished(double[] entropy)
    {
      FireListeners(delegate(IComputeEntropyListener<Q> listener)
                      {
                        listener.OnComputeEntropyFinished(entropy);
                      });

    }

    private void OnComputeEntropyStarted()
    {
      FireListeners(delegate(IComputeEntropyListener<Q> listener)
                      {
                        listener.OnComputeEntropyStarted();
                      });
    }

    private class Controller : IEntropyEvaluatorController<Q>
    {
      private readonly ComputeEntropyListener<T, Q> myHost;
      private readonly IGraph<Q> myGraph;
      private readonly IGraphStrongComponents<Q> myComponents;
      private readonly List<double> myResults = new List<double>();
      private ICellCoordinateSystem<Q> mySystem;

      public Controller(IGraph<Q> graph, IGraphStrongComponents<Q> components, ComputeEntropyListener<T, Q> host)
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

      public bool SubdivideNext(ICellCoordinateSystem<Q> system)
      {
        return system.Subdivision[0] > 10;
      }

      public void SetCoordinateSystem(ICellCoordinateSystem<Q> system)
      {
        mySystem = system;
      }

      public void OnResult(double result, IDictionary<Q, double> measure)
      {
        myResults.Add(result);
        myHost.FireListeners(delegate(IComputeEntropyListener<Q> obj)
                               {
                                 obj.OnComputeEntropyStep(result, measure, mySystem);
                               });
      }
    }
  }
}