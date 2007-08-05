using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class DrawEntropyListener<T, Q> : ProvideExternalListenerBase<T, Q, IDrawEntropyImageListener>, IComputeEntropyListener<Q>, IComputationPathListener
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private int myStepNumber = 0;
    private readonly Dictionary<string, DrawBase> myDrawers = new Dictionary<string, DrawBase>();
    private readonly Hashset<string> myWorking = new Hashset<string>();

    public IEnumerable<Pair<string, Action<string>>> FormatPath
    {
      get {
        foreach (KeyValuePair<string, DrawBase> pair in myDrawers)
        {
          yield return pair.Value.FormatPath;
        }        
      }
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
      myStepNumber = 0;
    }

    public override void OnStepStarted(T system, AbstractImageBuilderContext<Q> cx, long[] subdivide)
    {   
      myWorking.Clear();

      if (AreAllEqual(system.Subdivision))
      {
        myWorking.AddRange(myDrawers.Keys);
      } else
      {
        foreach (KeyValuePair<string, DrawBase> pair in myDrawers)
        {
          if (pair.Key.StartsWith("Full"))
            myWorking.Add(pair.Key);
        }        
      }
      myWorking.Add("Measure");
     
      myStepNumber++;
    }

    private static bool AreAllEqual(long[] ls)
    {
      long l = ls[0];
      for(int i=1; i<ls.Length; i++)
      {
        if (l != ls[i])
          return false;
      }
      return true;
    }

    public override void ComputationFinished(IGraphStrongComponents<Q> comps, IGraph<Q> graph, T system,
                                             AbstractImageBuilderContext<Q> cx)
    {
      foreach (KeyValuePair<string, DrawBase> pair in myDrawers)
      {
        if (myWorking.Contains(pair.Key))
        {
          string image = pair.Value.DrawImage(pair.Key);

          FireListeners(delegate(IDrawEntropyImageListener obj)
                          {
                            obj.EntropyImageAdded(pair.Key, image);
                          });
        }
      }      
    }

    public void OnComputeEntropyStarted()
    {
      myEntropyStep = 0;
    }

    public void OnComputeEntropyFinished(double[] value)
    {
      foreach (KeyValuePair<string, DrawBase> pair in myDrawers)
      {
        if (myWorking.Contains(pair.Key) && pair.Value is DrawEntropyBase)
          ((DrawEntropyBase)pair.Value).AppendResult(value);
      }
    }

    private int myEntropyStep = 0;

    public void OnComputeEntropyStep(double value, IDictionary<Q, double> measure, ICellCoordinateSystem<Q> system)
    {
      if (myEntropyStep == 0)
      {
        foreach (KeyValuePair<string, DrawBase> pair in myDrawers)
        {
          if (myWorking.Contains(pair.Key))
          {
            DrawEntropyWithSpace<Q> sp = pair.Value as DrawEntropyWithSpace<Q>;
            if (sp != null)
              sp.SetMeasure(system, measure, value);
          }
        }
      }
      myEntropyStep++;
    }
  }
}