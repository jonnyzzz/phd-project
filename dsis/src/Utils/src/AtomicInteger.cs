namespace DSIS.Utils
{
  public class AtomicInteger
  {
    private readonly object LOCK = new object();
    private volatile int myData;

    public AtomicInteger(int data)
    {
      myData = data;
    }

    public AtomicInteger()
    {      
    }

    public int Add(int value)
    {
      lock(LOCK)
      {
        return myData += value;
      }
    }

    public int Dec(int value)
    {
      lock(LOCK)
      {
        return myData -= value;
      }
    }

    public int Value
    {
      get
      {
        lock(LOCK)
        {
          return myData;
        }
      }
    }
  }
}