using System;
using System.Collections.Generic;
using DSIS.GnuplotDrawer;
using DSIS.Graph;
using DSIS.IntegerCoordinates;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class CachedComponetPointsWriter : IComponentPointsWriter
  {
    private readonly IComponentPointsWriter myHost;
    private Type myT;
    private Type myQ;
    private object mySystem;
    private object myComponents;
    private List<IGnuplotPointsFile> myValue;

    public CachedComponetPointsWriter(IComponentPointsWriter host)
    {
      myHost = host;
    }

    public IEnumerable<IGnuplotPointsFile> WriteComponents<T, Q>(T system, IReadonlyGraphStrongComponents<Q> comps) 
      where T : IIntegerCoordinateSystem<Q> 
      where Q : IIntegerCoordinate
    {
      if (CacheMatch(system, comps))
      {
        return myValue;
      }
      FlushCache();

      var v = myHost.WriteComponents(system, comps);
      SetCacheMatch(system, comps, v);

      return myValue;
    }

    private void FlushCache()
    {
      myT = null;
      myQ = null;
      mySystem = null;
      myComponents = null;
      myValue = null;
    }

    private void SetCacheMatch<T,Q>(T system, IReadonlyGraphStrongComponents<Q> comps, IEnumerable<IGnuplotPointsFile> files)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      myT = typeof (T);
      myQ = typeof (Q);
      mySystem = system;
      myComponents = comps;
      myValue = new List<IGnuplotPointsFile>(files);
    }

    private bool CacheMatch<T,Q>(T system, IReadonlyGraphStrongComponents<Q> comps)
      where T : IIntegerCoordinateSystem<Q>
      where Q : IIntegerCoordinate
    {
      if (!Equals(myT, typeof(T)))
        return false;

      if (!Equals(myQ, typeof(Q)))
        return false;

      if (!Equals(mySystem, system))
        return false;

      if (!Equals(myComponents, comps))
        return false;

      return true;      
    }

  }
}