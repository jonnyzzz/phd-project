using System;
using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Graph.Entropy.Impl.JVR
{
  public class ItemUpdateCookie<T> : IDisposable 
    where T : ICellCoordinate
  {
    private readonly IHashholderController<T> myInstance;
    private readonly ArcDirection<T> myStrait;
    private readonly ArcDirection<T> myBack;

    private double? myError;

    private readonly HashSet<T> myNodesList = new HashSet<T>(EqualityComparerFactory<T>.GetComparer());

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
      double error = 0;
      foreach (var node in myNodesList)
      {
        var ch = myInstance.SetItem(node, myStrait.ComputeWeight(node), myBack.ComputeWeight(node));
        error += Math.Abs(ch);
      }
      myError = error;
    }

    public double Change
    {
      get
      {
        if (myError == null)
          throw new Exception("IDisposable.Dispose should be called before");

        return myError.Value;
      }
    }
  }
}