using System.Collections.Generic;
using DSIS.Core.Util;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  internal class SimpleTaskQueue
  {
    private readonly int myLimit;

    private Queue<Pair<Point, Point>> myItems;
    private int myProcessed = 0;
    private List<Point> myExceeded;

    public SimpleTaskQueue(int limit)
    {
      myLimit = limit;
      Clear();
    }

    public void AddTask(double[] weight, Pair<Point, Point> pt)
    {
      if (myProcessed < myLimit)
      {
        myProcessed++;
        myItems.Enqueue(pt);
      }
      else
      {
        myExceeded.Add(pt.First);
        myExceeded.Add(pt.Second);
      }
    }

    public void Clear()
    {
      myItems = new Queue<Pair<Point, Point>>(myLimit);
      myExceeded = new List<Point>();
      myProcessed = 0;
    }

    public bool HasNextTask
    {
      get { return myItems.Count > 0; }
    }

    public Pair<Point, Point> NextTask()
    {
      return myItems.Dequeue();
    }

    public IEnumerable<Pair<double[], Point>> NonProcessed
    {
      get { yield break; }
    }

    public IEnumerable<Point> Overlaped
    {
      get { return myExceeded; }
    }
  }
}