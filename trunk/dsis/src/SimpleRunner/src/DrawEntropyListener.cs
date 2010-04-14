using System;
using System.Collections.Generic;
using System.Linq;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.Graph.Entropy.Impl.Util;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class DrawEntropyListener<T, Q> : ProvideExternalListenerBase<T, Q, IDrawEntropyImageListener>,
                                           IComputeEntropyListener<Q>, IComputationPathListener
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
  {
    private int myStepNumber;
    private readonly Dictionary<string, DrawBase> myDrawers = new Dictionary<string, DrawBase>();
    private readonly HashSet<string> myWorking = new HashSet<string>();

    private readonly string mySuffix;
    private int myEntropyStep;

    public DrawEntropyListener(string suffix)
    {
      mySuffix = suffix;
    }

    public IEnumerable<Pair<string, Action<string>>> FormatPath
    {
      get {return myDrawers.Select(pair => pair.Value.FormatPath); }
    }

    public void ComputationTitle(string title)
    {
      foreach (KeyValuePair<string, DrawBase> pair in myDrawers)
      {
        pair.Value.Title = pair.Key + " " + title;
      }
    }

    public override void ComputationStarted(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric)
    {
      myDrawers["Full for the measure"] = new ProjectTheSameMeasureEntropyDraw();
      myDrawers["Full to the same"] = new ProjectToTheSameEntropyDraw();
      myDrawers["BigStep to the same"] = new ProjectToTheSameEntropyDraw();
      myDrawers["BigStep for the measure"] = new ProjectTheSameMeasureEntropyDraw();
      myDrawers["Measure"] = new DrawEntropyWithSpace<Q>();
      myDrawers["Measure3D"] = new DrawEntropyWithSpace3dSegments<Q>();
      myStepNumber = 0;
    }

    public override void OnStepStarted(T system, AbstractImageBuilderContext<Q> cx, long[] subdivide)
    {
      myWorking.Clear();

      if (AreAllEqual(system.Subdivision))
      {
        myWorking.UnionWith(myDrawers.Keys);
      }
      else
      {
        foreach (KeyValuePair<string, DrawBase> pair in myDrawers)
        {
          if (pair.Key.StartsWith("Full"))
            myWorking.Add(pair.Key);
        }
      }
      myWorking.Add("Measure");
      myWorking.Add("Measure3D");

      myStepNumber++;
    }

    private static bool AreAllEqual(long[] ls)
    {
      long l = ls[0];
      for (int i = 1; i < ls.Length; i++)
      {
        if (l != ls[i])
          return false;
      }
      return true;
    }

    public override void ComputationFinished(IReadonlyGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                             AbstractImageBuilderContext<Q> cx)
    {
      foreach (KeyValuePair<string, DrawBase> pair in myDrawers)
      {
        string key = mySuffix + " " + pair.Key;
        string image = pair.Value.DrawImage(key);
        
        if (image != null)
          FireListeners(obj => obj.EntropyImageAdded(key, image));
      }
    }

    public void OnComputeEntropyStarted()
    {
      myEntropyStep = 0;
    }

    public void OnComputeEntropyFinished(string key, double[] value)
    {
      foreach (KeyValuePair<string, DrawBase> pair in myDrawers)
      {
        if (myWorking.Contains(pair.Key) && pair.Value is DrawEntropyBase)
          ((DrawEntropyBase) pair.Value).AppendResult(value);
      }
    }

    public void OnComputeEntropyStep<P>(double value, IDictionary<Q, double> measure, IDictionary<P, double> edges, ICellCoordinateSystem<Q> system) where P : PairBase<Q>
    {
      if (myEntropyStep == 0)
      {
        foreach (KeyValuePair<string, DrawBase> pair in myDrawers)
        {
          if (myWorking.Contains(pair.Key))
          {
            var sp = pair.Value as DrawEntropyWithSpaceBase<Q>;
            if (sp != null)
              sp.SetMeasure(system, measure, value);
          }
        }
      }
      myEntropyStep++;
    }
  }
}