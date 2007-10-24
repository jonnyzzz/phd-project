using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class ItemRebuildCookie<T> : IDisposable where T : ICellCoordinate<T>
  {
    private readonly Dictionary<T, double> myValues = new Dictionary<T, double>(EqualityComparerFactory<T>.GetComparer());

    private readonly IHashholderController<T> myController;

    internal ItemRebuildCookie(IHashholderController<T> controller)
    {
      myController = controller;
    }

    public void SetItem(JVRPair<T> pair, double value)
    {
      myController.SetItem(pair, value);

      SetValue(pair.From, -value);
      SetValue(pair.To, value);      
    }

    private void SetValue(T node, double v)
    {
      double val;
      if (myValues.TryGetValue(node, out val))
        v += val;
      myValues[node] = v;
    }

    public void Dispose()
    {
      foreach (KeyValuePair<T, double> pair in myValues)
      {
        myController.SetItem(pair.Key, pair.Value, 0);
      }
    }
  }
}