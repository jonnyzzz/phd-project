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
    private readonly IEnumerator<T> myInput;
    private readonly int myBufferSize;
    private readonly IEnumerator<T> myResult;
    
    public BufferedThreadedCountEnumerable(Mutex readLock, IEnumerator<T> input, int bufferSize)
    {
      myMutex = readLock;
      myBufferSize = bufferSize;
      myInput = input;

      myResult = GetEnumeratorInternal();
    }

    public int Count
    {
      get { return 1; }
    }

    public IEnumerator<T> GetEnumerator()
    {
      return myResult;
    } 

    private IEnumerator<T> GetEnumeratorInternal()
    {
      var cache = new List<T>(myBufferSize);
      var input = myInput;

      while (true)
      {
        using (myMutex.Lock())
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