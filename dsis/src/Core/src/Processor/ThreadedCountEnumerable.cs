using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Core.Processor
{
  public class ThreadedCountEnumerable<T> : ICountEnumerable<T>
  {
    private readonly Mutex myMutex;
    private readonly ICountEnumerable<T> myInput;
    private readonly int myCount;

    public ThreadedCountEnumerable(Mutex mutex, ICountEnumerable<T> input)
    {
      myMutex = mutex;
      myInput = input;
      myCount = input.Count;
    }

    public int Count
    {
      get { return myCount; }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
      return new ThreadedEnumerator(myMutex, myInput.GetEnumerator());
    }

    public IEnumerator GetEnumerator()
    {
      return ((IEnumerable<T>) this).GetEnumerator();
    }

    private class ThreadedEnumerator : IEnumerator<T>
    {
      private readonly Mutex myMutex;
      private readonly IEnumerator<T> myInput;

      private T myCurrent;

      public ThreadedEnumerator(Mutex mutex, IEnumerator<T> input)
      {
        myMutex = mutex;
        myInput = input;
      }      

      T IEnumerator<T>.Current
      {
        get { return myCurrent; }
      }

      void IDisposable.Dispose()
      {        
        myInput.Dispose();
      }

      bool IEnumerator.MoveNext()
      {
        using(new MutexCookie(myMutex))
        {
          if (myInput.MoveNext())
          {
            myCurrent = myInput.Current;
            return true;
          }
          myCurrent = default(T);
          return false;
        }
      }

      void IEnumerator.Reset()
      {
        using(new MutexCookie(myMutex))
        {
          myCurrent = default(T);
          myInput.Reset();
        }
      }

      object IEnumerator.Current
      {
        get { return myCurrent; }
      }
    }
  }
}