using System;
using DSIS.Graph;
using DSIS.Graph.Abstract;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public class ConsoleListener<T, Q> : IAbstractImageBuilderListener<T, Q>, IComputeEntropyListener,
                                       IDrawLastComputationResultEvents
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {        
    private int stepCount = 0;
    
    public void ComputationStarted(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric)
    {
      Console.Out.WriteLine("Computation started.\r\nSystem {0},\r\nMethod {1},\r\nIcs {2}",cx.Info.PresentableName,cx.Builder.PresentableName,typeof(T).Name);
      Console.Out.WriteLine("isUnsimmetric = {0}", isUnsimmetric);
      Console.Out.WriteLine("{0}", DateTime.Now);

      stepCount = 0;
    }

    public void OnStepStarted(T system, AbstractImageBuilderContext<Q> cx, long[] subdivide)
    {
      stepCount++;
      Console.Out.WriteLine("Step {0} started.", stepCount);
      Console.Out.Write("subdivide = [");
      foreach (long d in subdivide)
      {
        Console.Out.Write("{0},",d);
      }
      Console.Out.WriteLine();
    }

    public void GraphConstructed(IGraph<Q> graph, T system, AbstractImageBuilderContext<Q> cx)
    {
      Console.Out.WriteLine("Graph constructed.Nodes = {0}", graph.NodesCount);      
    }

    public void GraphComponentsConstructed(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                           AbstractImageBuilderContext<Q> cx)
    {
      Console.Out.WriteLine("Graph components done. {0} components", comps.ComponentCount);
      Console.Out.Write("Components: ");
      foreach (IStrongComponentInfo info in comps.Components)
      {
        Console.Out.Write("{0}, ", info.NodesCount);        
      }
      Console.Out.Write("Components: ");      
    }

    public void OnStepFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                               AbstractImageBuilderContext<Q> cx)
    {
      Console.Out.WriteLine("Step {0} finished", stepCount);      
    }

    public void ComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                    AbstractImageBuilderContext<Q> cx)
    {
      Console.Out.WriteLine("Computation finished");      
    }

    public void OnComputeEntropyStarted()
    {
    }

    public void OnComputeEntropyFinished(double[] value)
    {
      foreach (double d in value)
      {
        Console.Out.WriteLine("Entropy {0}", d);      
      }      
    }

    public void ImageFile(string file)
    {
      Console.Out.WriteLine("Image built to {0}", file);      
    }
  }
}