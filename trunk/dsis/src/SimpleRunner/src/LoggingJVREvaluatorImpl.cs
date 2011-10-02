using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.JVR;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner
{
  public class LoggingJVREvaluatorImpl<Q> : JVRMeasure<Q>
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

    public LoggingJVREvaluatorImpl(IReadonlyGraph<Q> graph, IGraphStrongComponents<Q> components, JVRMeasureOptions opts, Logger log)
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