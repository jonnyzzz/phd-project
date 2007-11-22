using System.Threading;

namespace DSIS.Core.Concurrent
{
  public class SynchQueue<T>
  {
    private readonly object ROOT_LOCK = new object();
    private readonly object TAIL_LOCK = new object();

    private QueueItem myRoot = null;
    private QueueItem myTail = null;

    private ManualResetEvent myDataAppend = new ManualResetEvent(false);

    private sealed class QueueItem
    {
      public readonly T Value;
      public QueueItem Next = null;

      public QueueItem(T value)
      {
        Value = value;
      }
    }

    public void Enqueue(T t)
    {
      lock(TAIL_LOCK)
      {
        if (myTail == null)
        {
          lock(ROOT_LOCK)
          {
            myRoot = myTail = new QueueItem(t);
            myDataAppend.Set();
          }
        } else
        {
          myTail.Next = new QueueItem(t);
          myTail = myTail.Next;
        }
      }
    }

    public T Dequeue()
    {
      lock(ROOT_LOCK)
      {
        if (myRoot == null)
        {
          return default(T);
        } else
        {
          T result = myRoot.Value;
          myRoot = myRoot.Next;
          if (myRoot == null)
          {
            //myTail != null here! So no deadlock!
            lock(TAIL_LOCK)
            {
              myTail = null;
              myDataAppend.Reset();
            }
          }
          return result;
        }
      }      
    }

    public void WaitData()
    {
      myDataAppend.WaitOne();
    }
  }
}
