using System;
using System.Collections.Generic;
using System.Threading;
using DSIS.Core.Builders;
using DSIS.Core.Coordinates;
using DSIS.Utils;

namespace DSIS.Core.Processor
{
  public class ThreadedCellConnectionBuilder<TCell> : ICellConnectionBuilder<TCell>, IDisposable 
    where TCell : ICellCoordinate<TCell>
  {
    private readonly List<Pair<TCell, List<TCell>>> myCache = new List<Pair<TCell, List<TCell>>>();
    private readonly Mutex myMutex;
    private readonly ICellConnectionBuilder<TCell> mySynchBulder;

    public ThreadedCellConnectionBuilder(Mutex mutex, ICellConnectionBuilder<TCell> synchBulder)
    {
      myMutex = mutex;
      mySynchBulder = synchBulder;
    }

    public void ConnectToOne(TCell cell, TCell v)
    {
      using(TryMutexCookie tm = new TryMutexCookie(myMutex))
      {
        if (tm.IsUnderMutex)
        {
          FlushCaches();
          mySynchBulder.ConnectToOne(cell, v);          
        } else
        {
          List<TCell> list = new List<TCell>();
          list.Add(v);
          myCache.Add(new Pair<TCell, List<TCell>>(cell, list));
        }
      }      
    }

    public void ConnectToMany(TCell cell, IEnumerable<TCell> v)
    {
      using (TryMutexCookie tm = new TryMutexCookie(myMutex))
      {
        if (tm.IsUnderMutex)
        {
          FlushCaches();
          mySynchBulder.ConnectToMany(cell, v);
        }
        else
        {
          myCache.Add(new Pair<TCell, List<TCell>>(cell, new List<TCell>(v)));
        }
      }      
    }

    private void FlushCaches()
    {
      foreach (Pair<TCell, List<TCell>> pair in myCache)
      {
        mySynchBulder.ConnectToMany(pair.First, pair.Second);
      }          
      myCache.Clear();
    }

    public void Dispose()
    {
      using(new MutexCookie(myMutex))
      {
        FlushCaches();
      }
    }
  }
}