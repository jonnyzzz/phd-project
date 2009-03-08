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

    public BufferedThreadedCountEnumerable(Mutex readLock, ICountEnumerable<T> input, int bufferSize)
    {
      myMutex = readLock;
      myBufferSize = bufferSize;
      myInput = input;
      myCount = input.Count;
    }

    public int Count
    {
      get { return myCount; }
    }

    public IEnumerator<T> GetEnumerator()
    {
      var cache = new List<T>(myBufferSize);
      var input = myInput.GetEnumerator();

      while (true)
      {
        using (new MutexCookie(myMutex))
        {
          for (int i = 0; i < myBufferSize && input.MoveNext(); i++)
          {
            cache.Add(input.Current);
          }
        }

        if (cache.Count == 0)
          yield break;

        foreach (var t in cache)
          yield return t;

        cache.Clear();
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IEnumerable<T>)this).GetEnumerator();
    }
  }
}