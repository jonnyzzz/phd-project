using System.Collections.Generic;
using DSIS.Core.Util;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  internal class SimpleTaskQueue : ISortedTaskQueue
  {
    private Queue<Pair<Point, Point>> myItems;
    private readonly int myLimit;
    private int myProcessed = 0;

    public SimpleTaskQueue(int limit)
    {
      myLimit = limit;
      myItems = new Queue<Pair<Point, Point>>(limit);
    }

    public Pair<Point, Point> NextTask()
    {
      return myItems.Dequeue();
    }

    public bool HasNextTask
    {
      get { return myItems.Count > 0; }
    }

    public void AddTask(double weight, Pair<Point, Point> pt)
    {
      myProcessed++;
      if (myProcessed < myLimit)
        myItems.Enqueue(pt);
    }

    public IEnumerable<Pair<double, Point>> NonProcessed
    {
      get { yield break; }
    }

    public void Clear()
    {
      myItems.Clear();
      myProcessed = 0;
    }
  }
}