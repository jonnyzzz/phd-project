using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class ItemUpdateCookie<T> : IDisposable where T : ICellCoordinate<T>
  {
    private readonly IHashholderController<T> myInstance;
    private readonly ArcDirection<T> myStrait;
    private readonly ArcDirection<T> myBack;

    private readonly Hashset<T> myNodesList = new Hashset<T>();

    internal ItemUpdateCookie(IHashholderController<T> instance, ArcDirection<T> strait, ArcDirection<T> back)
    {
      myInstance = instance;
      myStrait = strait;
      myBack = back;
    }

    public void SetItem(JVRPair<T> pair, double value)
    {
      myInstance.SetItem(pair, value);
      myNodesList.Add(pair.To);
      myNodesList.Add(pair.From);
    }

    public void Dispose()
    {
      foreach (T node in myNodesList)
      {
        myInstance.SetItem(node, myStrait.ComputeWeight(node), myBack.ComputeWeight(node));
      }
    }
  }
}