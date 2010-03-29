using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Graph.Entropy.Impl.Loop.Weight;
using DSIS.Scheme;
using DSIS.Scheme.Ctx;
using DSIS.Scheme.Impl.Actions.Entropy;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public abstract class ThesisJVREntropyBuildBase :
    ThesisEntropyBuildBase<EntropyComputationData<object>, object>
  {
    protected override IEnumerable<object> GetEntropComputationMode(
      AfterSIParams<EntropyComputationData<object>> afterSIParams)
    {
      yield return new object();
    }

    protected override void RemoveActionFrom(List<EntropyComputationData<object>> actions, EntropyComputationData<object> computationData, object mode)
    {
      //NOP.
    }

    protected override Func<Pair<IAction, string>> GetEntropyAction(object mode)
    {
      return () => CreateJVRMeasureAction(1e-05);
    }

    private static Pair<IAction, string> CreateJVRMeasureAction(double eps)
    {
      var opts = new JVRMeasureOptions
                   {
                     IncludeSelfEdge = false,
                     InitialWeight = EntropyLoopWeights.CONST,
                     EPS = eps,
                     ExitCondition = JVRExitCondition.EdgesChangeError //FAKE!
                   };
      return Pair.Of((IAction) new LoggingJVRMeasureAction(opts), opts.Present);
    }

    private class LoggingJVRMeasureAction : JVRMeasureAction
    {
      public LoggingJVRMeasureAction(JVRMeasureOptions opts) : base(opts)
      {
      }

      protected override JVREvaluator<Q> CreateEvaluator<Q>(JVRMeasureOptions opts, Context ctx)
      {
        return new JVREvaluatorEx<Q>(opts, Logger.Instance(ctx));
      }
    }

    private class JVREvaluatorEx<Q> : JVREvaluator<Q>
      where Q : ICellCoordinate
    {
      private readonly Logger myLogger;

      public JVREvaluatorEx(JVRMeasureOptions opts, Logger logger) : base(opts)
      {
        myLogger = logger;
      }

      protected override JVRMeasure<Q> CreateMeasure(IGraph<Q> graph, IGraphStrongComponents<Q> comps)
      {
        return new LoggingEvaluator<Q>(graph, comps, myOpts, myLogger);
      }
    }

    private class LoggingEvaluator<Q> : JVRMeasure<Q>
      where Q : ICellCoordinate
    {
      private readonly IGraphStrongComponents<Q> myComponents;
      private readonly Logger myLog;
      private int stepCount;
      private readonly Dictionary<JVRExitCondition, string> myCovergace = new Dictionary<JVRExitCondition, string>();
      private readonly List<JVRExitCondition> myConditions = Enum.GetValues(typeof(JVRExitCondition)).Cast<JVRExitCondition>().ToList();
      private readonly List<JVRExitCondition> myConditionsTmp = new List<JVRExitCondition>();
      private const int STEPS_LIMIT = 100 * 1000;
      private readonly DateTime myStartTime;

      public LoggingEvaluator(IGraph<Q> graph, IGraphStrongComponents<Q> components, JVRMeasureOptions opts, Logger log)
        : base(graph, components, opts)
      {
        myComponents = components;
        myLog = log;
        myStartTime = DateTime.Now;
      }

      private string TotalTime()
      {
        return (long)((DateTime.Now - myStartTime).TotalMilliseconds) + "ms";
      }

      private void DumpConvergance()
      {
        //TODO: Performance LAG!
        var graph = myComponents.AsGraph(myComponents.Components);
        var nodes = graph.NodesCount;
        var edges = graph.EdgesCount;

        myLog.Write("Graph nodes {0}, edges {1}", nodes, edges);
        foreach (var pair in myCovergace)
        {
          myLog.Write("{0} => {1}", pair.Key, pair.Value);
        }
      }

      protected override bool CheckExitCondition(JVRExitCondition condition, double precision, double totalError, double qValue, double nodesChange,
                                                 double edgesChange)
      {
        var b = CheckExitConditionEx(precision, totalError, qValue, nodesChange, edgesChange);
        if (b)
          DumpConvergance();

        return b;
      }

      private bool CheckExitConditionEx(double precision, double totalError, double qValue, double nodesChange, double edgesChange)
      {
        stepCount++;
/*
        myLog.Write("{6} --> {5} precision:{0}, totalError:{1}, q:{2}, nodesChange:{3}, edgesChange:{4}",
                    precision, totalError, qValue, nodesChange, edgesChange, ++stepCount, TotalTime());

*/        
        bool remove = false;
        foreach (JVRExitCondition exitCondition in myConditions)
        {
          if (base.CheckExitCondition(exitCondition, precision, totalError, qValue, nodesChange, edgesChange))
          {
            myLog.Write("{1} ----> {0} completed", exitCondition, TotalTime());
            myCovergace[exitCondition] = string.Format("{0}ms, {1}steps", TotalTime(), stepCount);
            myConditionsTmp.Add(exitCondition);
            remove = true;
          }
        }

        if (remove)
        {
          foreach (var condition in myConditionsTmp)
          {
            myConditions.Remove(condition);
          }
          myConditionsTmp.Clear();
        }
        

        if (stepCount > STEPS_LIMIT)
        {
          foreach (var exitCondition in myConditions)
          {
            myCovergace[exitCondition] = string.Format("{0}ms, {1}steps", TotalTime(), stepCount);
          }
          myLog.Write("{1} Steps limit of {0} acieved", STEPS_LIMIT, TotalTime());
          return true;
        }

        return myConditions.Count == 0;
      }
    }
  }
}