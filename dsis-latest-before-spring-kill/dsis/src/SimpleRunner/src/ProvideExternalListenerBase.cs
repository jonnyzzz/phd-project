using System;
using System.Collections.Generic;
using DSIS.IntegerCoordinates;

namespace DSIS.SimpleRunner
{
  public abstract class ProvideExternalListenerBase<T,Q,L> : AbstractImageBuilderListener<T,Q>, IProvideExtendedListener
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate
    where L : class
  {
    private readonly List<L> myListeners = new List<L>();

    public void AddListener(object o)
    {
      L listener = o as L;
      if (listener != null)
        myListeners.Add(listener);
    }

    public void RemoveListener(object o)
    {
      L listener = o as L;
      if (listener != null)
        myListeners.Remove(listener);
    }

    public void FireListeners(Action<L> action)
    {
      myListeners.ForEach(action);
    }
    
  }
}