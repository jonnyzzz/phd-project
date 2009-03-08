using System;
using System.Collections.Generic;
using System.Threading;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Core.Processor
{
  public class ThreadedCellConnectionBuilder<TCell> : ICellConnectionBuilder<TCell>, IDisposable 
    where TCell : ICellCoordinate
  {
    private readonly int myCacheSize;
    private readonly List<Pair<TCell, IEnumerable<TCell>>> myCacheMany = new List<Pair<TCell, IEnumerable<TCell>>>();
    private readonly List<Pair<TCell, TCell>> myCacheOne = new List<Pair<TCell, TCell>>();
    private readonly Mutex myWriteLock;
    private readonly ICellConnectionBuilder<TCell> mySynchBulder;

    public ThreadedCellConnectionBuilder(Mutex writeLock, ICellConnectionBuilder<TCell> synchBulder, int cacheSize)
    {
      myCacheSize = cacheSize;
      myWriteLock = writeLock;
      mySynchBulder = synchBulder;
    }

    public void ConnectToOne(TCell cell, TCell v)
    {
      myCacheOne.Add(new Pair<TCell, TCell>(cell, v));    
      FlushCachesIfNeeded();
    }

    public void ConnectToMany(TCell cell, IEnumerable<TCell> v)
    {
      myCacheMany.Add(new Pair<TCell, IEnumerable<TCell>>(cell, new List<TCell>(v)));
      FlushCachesIfNeeded();
    }

    private void FlushCachesIfNeeded()
    {
      if (myCacheMany.Count + myCacheOne.Count <= myCacheSize) 
        return;
      
      using(new MutexCookie(myWriteLock))
      {
        FlushCaches();
      }
    }

    private void FlushCaches()
    {
      foreach (var pair in myCacheMany)
      {
        mySynchBulder.ConnectToMany(pair.First, pair.Second);
      }          
      foreach (var pair in myCacheOne)
      {
        mySynchBulder.ConnectToOne(pair.First, pair.Second);
      }          
      myCacheMany.Clear();
      myCacheOne.Clear();
    }

    public void Dispose()
    {
      using(new MutexCookie(myWriteLock))
      {
        FlushCaches();
      }
    }
  }
}