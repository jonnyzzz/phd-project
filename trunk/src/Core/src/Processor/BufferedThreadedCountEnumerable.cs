using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DSIS.Core.Util;
using DSIS.Utils;

namespace DSIS.Core.Processor
{
  public class BufferedThreadedCountEnumerable<T> : ICountEnumerable<T>
  {
    private readonly Mutex myMutex;
    private readonly ICountEnumerable<T> myInput;
    private readonly int myCount;
    private readonly int myBufferSize;

    public BufferedThreadedCountEnumerable(Mutex mutex, ICountEnumerable<T> input, int bufferSize)
    {
      myMutex = mutex;
      myBufferSize = bufferSize;
      myInput = input;
      myCount = input.Count;
    }

    public int Count
    {
      get { return myCount; }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
      return new ThreadedEnumerator(myMutex, myInput.GetEnumerator(), myBufferSize);
    }

    public IEnumerator GetEnumerator()
    {
      return ((IEnumerable<T>)this).GetEnumerator();
    }

    private class ThreadedEnumerator : IEnumerator<T>
    {
      private readonly Mutex myMutex;
      private readonly IEnumerator<T> myInput;
      private readonly int myBufferSize;
      private readonly Queue<T> myCurrents;
      
      private bool myCollectionFinished = false;

      public ThreadedEnumerator(Mutex mutex, IEnumerator<T> input, int bufferSize)
      {
        myCurrents = new Queue<T>(bufferSize + 1);
        myMutex = mutex;
        myBufferSize = bufferSize;
        myInput = input;
      }

      T IEnumerator<T>.Current
      {
        get { return myCurrents.Peek(); }
      }

      void IDisposable.Dispose()
      {
        myInput.Dispose();
      }

      public bool MoveNext()
      {
        if (myCurrents.Count > 1)
        {
          myCurrents.Dequeue();
          return true;
        } if (!myCollectionFinished)
        {
          bool willReturn = false;
          if (myCurrents.Count == 1)
          {
            myCurrents.Dequeue();
          }

          using (new MutexCookie(myMutex))
          {
            bool lastNext;
            while ((lastNext = myInput.MoveNext()) && myCurrents.Count < myBufferSize)
            {
              myCurrents.Enqueue(myInput.Current);              
            }
            myCollectionFinished = !lastNext;            
            
            return myCurrents.Count > 0;
          }
        }
        else return false;
      }

      void IEnumerator.Reset()
      {
        using (new MutexCookie(myMutex))
        {
          myCurrents.Clear();
          myCollectionFinished = false;
          myInput.Reset();
        }
      }

      object IEnumerator.Current
      {
        get { return myCurrents.Peek(); }
      }
    }
  }
}