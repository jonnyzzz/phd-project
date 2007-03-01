using System.Collections.Generic;
using DSIS.Core.Util;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  internal class SimpleTaskQueue : ISortedTaskQueue
  {
    private readonly int myLimit;
    private readonly int myDim;

    private Queue<Pair<Point, Point>> myItems;
    private int myProcessed = 0;
    private double[] myMaxSize;
    private List<Point> myExceeded;

    public SimpleTaskQueue(int limit, int dim)
    {
      myDim = dim;
      myLimit = limit;
      Clear();
    }

    #region ISortedTaskQueue Members

    public void AddTask(double[] weight, Pair<Point, Point> pt)
    {
      if (weight != null)
      {
        for (int i = 0; i < myDim; i++)
        {
          if (myMaxSize[i] < weight[i])
            myMaxSize[i] = weight[i];
        }
      }
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
      myMaxSize = new double[myDim];
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

    public IEnumerable<double[]> Overlaped
    {
      get { yield break; }
    }

    #endregion
  }
}