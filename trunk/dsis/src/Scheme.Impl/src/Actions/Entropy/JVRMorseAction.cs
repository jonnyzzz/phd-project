using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.System;
using DSIS.Graph;
using DSIS.Graph.Morse;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class JVRMorseAction : IntegerCoordinateSystemActionBase3
  {
    private readonly MorseEvaluatorOptions myOptions;

    public JVRMorseAction(MorseEvaluatorOptions options)
    {
      myOptions = options;
    }

    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      return ColBase(base.Check<T,Q>(ctx), Create(Keys.IntegerCoordinateSystemInfo),
        Create(Keys.SystemInfoKey), Create(Keys.GetGraphComponents<Q>()));
    }

    protected override void Apply<T, Q>(Context input, Context output)
    {
      var system = Keys.IntegerCoordinateSystemInfo.Get(input);
      var function = Keys.SystemInfoKey.Get(input).GetFunction<double>(system.CellSizeHalf);
      var comps = Keys.GetGraphComponents<Q>().Get(input);

      var diffFunction = (IDetDiffFunction<double>) function;
      var dic = new Dictionary<IStrongComponentInfo, JVRMorseMinMax<Q>>();

      int i = 1;
      Func<string> tmpFile = () => string.Format(@"e:\morse-{0}-c{1}.txt", DateTime.Now.ToFileTime(), i++);

      foreach (var comp in comps.Components)
      {
        var asGraph = comps.AsGraph(comp.Enum());
        var ev = new GraphWith<Q>(diffFunction, myOptions, tmpFile);
        asGraph.DoGeneric(ev);
        dic.Add(comp, ev.Result);
      }

      Keys.Morse<Q>().Set(output, new JVRMorseResult<Q>(dic));
    }

    private class GraphWith<Q> : IReadonlyGraphWith<Q>
      where Q : IIntegerCoordinate
    {
      private readonly IDetDiffFunction<double> myFunction;
      private readonly MorseEvaluatorOptions myOpts;
      private readonly Func<string> myTempFiles;

      public JVRMorseMinMax<Q> Result { get; private set; }

      public GraphWith(IDetDiffFunction<double> function, MorseEvaluatorOptions opts, Func<string> tempFiles)
      {
        myFunction = function;
        myOpts = opts;
        myTempFiles = tempFiles;
      }

      public void With<TNode>(IReadonlyGraph<Q, TNode> graph) where TNode : class, INode<Q>
      {
        var evaluator = new DetDiffMorseEvaluator<TNode, Q>(myFunction, (IIntegerCoordinateSystem<Q>) graph.CoordinateSystem);        
        var min = Minimize(graph, evaluator);

        var max = Minimize(graph, new NegativeCost<TNode>(evaluator)).Negative();

        Result = new JVRMorseMinMax<Q>(Convert(max), Convert(min));
      }

      private ComputationResult<TNode> Minimize<TNode>(IReadonlyGraph<Q, TNode> graph, IMorseEvaluatorCost<TNode> evaluator)
        where TNode : class, INode<Q>
      {
        var eval = new MorseEvaluator<TNode>(myOpts, new MorseStrongComponentGraph<TNode,Q>(graph), evaluator);
        eval.AddPersist(new JVRFormatPersist<TNode>(myTempFiles));
        return eval.Minimize();
      }

      private static ComputationResult<Q> Convert<TNode>(ComputationResult<TNode> result) where TNode : INode<Q>
      {
        return new ComputationResult<Q>(result.Value, result.Contour.Select(x=>x.Coordinate).ToArray());
      }

      public class DetDiffMorseEvaluator<T, Q> : IMorseEvaluatorCost<T>
        where T : INode<Q>
        where Q : IIntegerCoordinate
      {
        private readonly IDetDiffFunction<double> myFunction;
        private readonly double[] myCoords;
        private readonly IIntegerCoordinateSystem<Q> mySystem;

        public DetDiffMorseEvaluator(IDetDiffFunction<double> function, IIntegerCoordinateSystem<Q> system)
        {
          myFunction = function;
          myCoords = new double[myFunction.Dimension];
          mySystem = system;
        }

        public double Cost(T node)
        {
          mySystem.CenterPoint(node.Coordinate, myCoords);
          return Math.Log(Math.Abs(myFunction.Evaluate(myCoords)));
        }
      }
    }
  }
}