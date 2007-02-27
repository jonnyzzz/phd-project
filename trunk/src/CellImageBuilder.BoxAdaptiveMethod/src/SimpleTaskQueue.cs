using System.Collections.Generic;
using DSIS.Core.Util;
using DSIS.Util;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  internal class SimpleTaskQueue : ISortedTaskQueue
  {
    private readonly int myLimit;
    private readonly int myDim;

    private Queue<Pair<Point, Point>> myItems;    
    private int myProcessed = 0;    
    private double[] myMaxSize;
    private Hashset<Point> myExceeded;


    public SimpleTaskQueue(int limit, int dim)
    {
      myDim = dim;
      myLimit = limit;
      Clear();
    }

    public Pair<Point, Point> NextTask()
    {
      return myItems.Dequeue();
    }

    public bool HasNextTask
    {
      get { return myItems.Count > 0; }
    }

    public void AddTask(double[] weight, Pair<Point, Point> pt)
    {
      if (weight != null)
      {        
        for(int i=0; i<myDim; i++)
        {
          if (myMaxSize[i] < weight[i])
            myMaxSize[i] = weight[i];
        }
      }
      if (myProcessed < myLimit)
      {
        myProcessed++;
        myItems.Enqueue(pt);
      } else
      {
        myExceeded.Add(pt.First);
        myExceeded.Add(pt.Second);
      }
    }

    public IEnumerable<double[]> Overlaped
    {
      get { yield break; }
    }

    public IEnumerable<Pair<double[], Point>> NonProcessed
    {
      get
      {/*
        foreach (Point point in myExceeded)
        {
          yield return new Pair<double[], Point>(myMaxSize, point);
        }        
        */
        yield break;
      }
    }

    public void Clear()
    {
      myItems = new Queue<Pair<Point, Point>>(myLimit);
      myMaxSize = new double[myDim];
      myExceeded = new Hashset<Point>(PointEqualityComparer.INSTANCE);
      myProcessed = 0;
    }
  }
}