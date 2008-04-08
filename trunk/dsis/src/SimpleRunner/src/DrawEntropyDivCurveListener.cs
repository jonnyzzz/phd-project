using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DSIS.Core.Coordinates;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class DrawEntropyCurveListener<T, Q> : ProvideExternalListenerBase<T, Q, IDrawEntropyImageListener>,
                                                   IComputeEntropyListener<Q>, IComputationPathListener
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {    
    private string myTitle;
    private string myPath;
    private IGnuplotLineScriptGen myGen;
    private Dictionary<string, List<double>> myData;

    public IEnumerable<Pair<string, Action<string>>> FormatPath
    {
      get { yield return new Pair<string, Action<string>>("{0}", delegate(string path) { myPath = path; }); }
    }

    public void ComputationTitle(string title)
    {
      myTitle = title;
    }


    public override VoidDelegate ComputationStartedC(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric)
    {
      myData = new Dictionary<string, List<double>>();
      return base.ComputationStartedC(system, cx, isUnsimmetric);
    }

    public void OnComputeEntropyStarted()
    {      
    }

    public void OnComputeEntropyFinished(string key, double[] value)
    {
      List<double> l;
      if (!myData.TryGetValue(key, out l))
      {
        l = new List<double>();
        myData[key] = l;
      }
      l.Add(value[0]);      
    }

    public override VoidDelegate ComputationFinishedC(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                                      AbstractImageBuilderContext<Q> cx)
    {
      string output = Path.Combine(myPath, "entropy-curve");
      Directory.CreateDirectory(output);
      myGen = GnuplotSriptGen.CreateLines(Path.Combine(output, "curve"), new GnuplotScriptParameters(Path.Combine(output, "curves.png"), "Entropy on division " + myTitle));      

      foreach (KeyValuePair<string, List<double>> pair in myData)
      {
        myGen.AddSeria(pair.Key, pair.Value);
      }
      myGen.Finish();
      new GnuplotDrawer.GnuplotDrawer().DrawImage(myGen);
      return base.ComputationFinishedC(comps, graph, system, cx);
    }

    public void OnComputeEntropyStep<P>(double value, IDictionary<Q, double> measure, IDictionary<P, double> edges, ICellCoordinateSystem<Q> system) where P:PairBase<Q>
    {      
    }
  }
}