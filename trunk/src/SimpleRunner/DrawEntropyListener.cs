using System;
using System.Collections.Generic;
using DSIS.Graph;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.SimpleRunner
{
  public class DrawEntropyListener<T, Q> : ProvideExternalListenerBase<T, Q, IDrawEntropyImageListener>, IComputeEntropyListener, IComputationPathListener
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private readonly Dictionary<string, DrawEntropyUtil> myDrawers = new Dictionary<string, DrawEntropyUtil>();
    private readonly Hashset<string> myWorking = new Hashset<string>();

    public IEnumerable<Pair<string, Action<string>>> FormatPath
    {
      get {
        foreach (KeyValuePair<string, DrawEntropyUtil> pair in myDrawers)
        {
          yield return pair.Value.FormatPath;
        }        
      }
    }

    public void ComputationTitle(string title)
    {
      foreach (KeyValuePair<string, DrawEntropyUtil> pair in myDrawers)
      {
        pair.Value.Title = pair.Key + " " + title;
      }
    }

    public override void ComputationStarted(T system, AbstractImageBuilderContext<Q> cx, bool isUnsimmetric)
    {
      myDrawers["Full"] = new DrawEntropyUtil();
      myDrawers["BigStep"] = new DrawEntropyUtil();      
    }

    public override void OnStepStarted(T system, AbstractImageBuilderContext<Q> cx, long[] subdivide)
    {   
      myWorking.Clear();

      if (AreAllEqual(system.Subdivision))
      {
        myWorking.AddRange(myDrawers.Keys);
      } else
      {
        myWorking.Add("Full");
      }
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
      foreach (KeyValuePair<string, DrawEntropyUtil> pair in myDrawers)
      {
        string image = pair.Value.DrawImage(pair.Key);

        FireListeners(delegate(IDrawEntropyImageListener obj)
                        {
                          obj.EntropyImageAdded(pair.Key, image);
                        });  
      }      
    }

    public void OnComputeEntropyStarted()
    {
    }

    public void OnComputeEntropyFinished(double[] value)
    {
      foreach (KeyValuePair<string, DrawEntropyUtil> pair in myDrawers)
      {
        if (myWorking.Contains(pair.Key))
          pair.Value.AppendResult(value);
      }
    }
  }
}