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

    private double[] eps;
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
    private Divide[] div2;
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

      eps = new double[myDim];
      for (int i = 0; i < myDim; i++)
        eps[i] = mySystem.CellSize[i]*settings.CellSizePercent;

      radius = new double[myDim];
      for (int i = 0; i < myDim; i++)
        radius[i] = mySystem.CellSize[i];

      divLeft = new Divide[myDim];
      divMiddle = new Divide[myDim];
      divRight = new Divide[myDim];
      div = new Divide[myDim];
      div2 = new Divide[myDim];
      double[] per = new double[myDim];
      for (int i = 0; i < myDim; i++)
      {
        divLeft[i] = Divide.First;
        divMiddle[i] = Divide.Middle;
        divRight[i] = Divide.Second;
        per[i] = settings.Overlaping;
      }

      myAdapter.AddPointWithOverlappingPrepare(per, overlapL, overlapR);
    }

    private bool checkEpsilon(double[] d1, double[] d2, out double length)
    {
      length = 0;
      bool flag = true;
      for (int i = 0; i < myDim; i++)
      {
        double t = Math.Abs(d1[i] - d2[i]);
        length += t;
        flag &= t <= eps[i];
      }
      return flag;
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

      double len = 0;
      bool result = true;
      for (int i = 0; i < myDim; i++)
      {
        double t = Math.Abs(d1[i] - d2[i]);
        len += t;
        bool b = t <= eps[i];
        if (b)
        {
          div2[i] = Divide.First;
          divLeft[i] = Divide.Middle;
          divRight[i] = Divide.Middle;
        } else
        {
          div2[i] = Divide.Middle;
          divLeft[i] = Divide.First;
          divRight[i] = Divide.Second;
        }
        div2[i] = b ? Divide.First : Divide.Middle;
        result &= b;
      }
      if (result)
      {
        AppendPoint(p1, d1);
        AppendPoint(p2, d2);
      }
      else
      {
        foreach (Divide[] ts in BoxIterator.EnumerateBox(divLeft, divRight, div))
        {
          for (int i = 0; i < myDim; i++)
          {
            if (div2[i] != Divide.Middle)
              div2[i] = ts[i] == Divide.First ? Divide.Second : Divide.First;
          }
          queue.AddTask(len, 
            new Pair<Point, Point>(
              Point.Middle(p1, p2, div2), 
              Point.Middle(p1, p2, ts)
              )
              );
        }
      }
    }
  }
}