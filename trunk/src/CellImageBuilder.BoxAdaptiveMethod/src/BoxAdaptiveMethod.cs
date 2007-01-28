using System;
using System.Collections.Generic;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.Core.Util;
using DSIS.IntegerCoordinates;
using DSIS.Util;

namespace DSIS.CellImageBuilder.BoxAdaptiveMethod
{
  public class BoxAdaptiveMethod : IntegerCoordinateMethodBase, ICellImageBuilder<IntegerCoordinate>
  {
    private IFunction<double> myFunction;
    private double[] x;
    private double[] y;
    private double[] xleft;
    private double[] xright;

    private double eps;
    private double[] radius;
    private IntegerCoordinate coordinate;
    private double[] overlapL;
    private double[] overlapR;

    private Dictionary<Point, double[]> cache = new Dictionary<Point, double[]>(new PointEqualityComparer());
    private Hashset<Point> addedPoints = new Hashset<Point>(new PointEqualityComparer());
    private Divide[] divLeft;
    private Divide[] divMiddle;
    private Divide[] divRight;
    private Divide[] div;
    private ISortedTaskQueue myQueue;    

    private double[] Evaluate(Point pt)
    {
      double[] result;
      if (cache.TryGetValue(pt, out result))
        return result;

      pt.Evaluate(xleft, xright, x);
      result = new double[x.Length];
      myFunction.Output = result;
      myFunction.Evaluate();

      cache[pt] = result;

      return result;
    }

    public override void Bind(CellImageBuilderContext<IntegerCoordinate> context)
    {
      base.Bind(context);
      myFunction = context.Function.GetFunction<double>();
      cache.Clear();

      BoxAdaptiveMethodSettings settings = (BoxAdaptiveMethodSettings) context.Settings;
      switch (settings.WorkItemStrategy)
      {
        case BoxAdaptiveMethodStategy.Simple:
          myQueue = new SimpleTaskQueue(settings.TaskLimit);
          break;
      }

      x = new double[myDim];
      y = new double[myDim];
      xleft = new double[myDim];
      xright = new double[myDim];
      overlapL = new double[myDim];
      overlapR = new double[myDim];

      myFunction.Input = x;
      myFunction.Output = y;

      eps = 0;
      for (int i = 0; i < myDim; i++)
        eps += mySystem.CellSize[i];
      eps /= 2;

      radius = new double[myDim];
      for (int i = 0; i < myDim; i++)
        radius[i] = mySystem.CellSize[i];

      divLeft = new Divide[myDim];
      divMiddle = new Divide[myDim];
      divRight = new Divide[myDim];
      div = new Divide[myDim];
      double[] per = new double[myDim];
      for (int i = 0; i < myDim; i++)
      {
        divLeft[i] = Divide.Middle;
        divMiddle[i] = Divide.Middle;
        divRight[i] = Divide.Middle;
        per[i] = settings.Overlaping;
      }

      myAdapter.AddPointWithOverlappingPrepare(per, overlapL, overlapR);
    }

    private double epsilon(double[] d1, double[] d2)
    {
      double e = 0;
      for (int i = 0; i < myDim; i++)
      {
        e += Math.Abs(d1[i] - d2[i]);
      }

      return e;
    }

    private bool checkEpsilon(double[] d1, double[] d2, out double length)
    {
      return (length = epsilon(d1, d2)) > eps;
    }

    public void BuildImage(IntegerCoordinate coord)
    {
      coordinate = coord;

      mySystem.TopLeftPoint(coord, xleft);
      for (int i = 0; i < myDim; i++)
        xright[i] = xleft[i] + mySystem.CellSize[i];

      Point topPoint = Point.CreateTopLeft(myDim);
      Point bottomPoint = Point.CreateBottomRight(myDim);

      myQueue.Clear();
      addedPoints.Clear();
      cache.Clear();
      
      myQueue.AddTask(0, new Pair<Point, Point>(topPoint, bottomPoint));

      while (myQueue.HasNextTask)
      {
        ProcessPoint(myQueue.NextTask(), myQueue);
      }

      addedPoints.Clear(); //sizes may differ. 
      foreach (Pair<double, Point> work in myQueue.NonProcessed)
      {
        double[] sz = new double[myDim];
        for (int i = 0; i < myDim; i++)
          sz[i] = work.First;

        myAdapter.ConnectCellToPointWithRadius(coord, Evaluate(work.Second), sz);
      }
    }

    private void AppendPoint(Point p, double[] d)
    {
      if (!addedPoints.Contains(p))
      {
        myAdapter.AddPointWithOverlapping(coordinate, d, overlapL, overlapR);
        addedPoints.Add(p);
      }
    }

    private void ProcessPoint(Pair<Point, Point> task, ISortedTaskQueue queue)
    {
      Point p1 = task.First;
      Point p2 = task.Second;

      double[] d1 = Evaluate(p1);
      double[] d2 = Evaluate(p2);

      double len;
      if (checkEpsilon(d1, d2, out len))
      {
        AppendPoint(p1, d1);
        AppendPoint(p2, d2);
      }
      else
      {
        Point m = Point.Middle(p1, p2, divMiddle);
        foreach (Divide[] ts in BoxIterator.EnumerateBox(divLeft, divRight, div))
        {
          queue.AddTask(len, new Pair<Point, Point>(m, Point.Middle(p1, p2, ts)));
        }
      }
    }
  }
}