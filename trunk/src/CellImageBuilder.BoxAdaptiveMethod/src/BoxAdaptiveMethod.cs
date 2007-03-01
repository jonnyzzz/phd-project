using System;
using System.Collections.Generic;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
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
    private double[] overlapL;
    private double[] overlapR;

    private Divide[] divLeft;
    private Divide[] divMiddle;
    private Divide[] divRight;
    private Divide[] div;
    private Divide[] div2;

    private ISortedTaskQueue myQueue;
    private BoxIterator<Divide> myIterator;
    private PointWithOverlappingProcessor myProcessor;

    private List<IntegerCoordinate> myPoints;

    #region ICellImageBuilder<IntegerCoordinate> Members

    public override void Bind(CellImageBuilderContext<IntegerCoordinate> context)
    {
      base.Bind(context);
      myProcessor = new PointWithOverlappingProcessor(mySystem);
      myPoints = new List<IntegerCoordinate>(10000);

      myFunction = context.Function.GetFunction<double>();

      BoxAdaptiveMethodSettings settings = (BoxAdaptiveMethodSettings) context.Settings;
      switch (settings.WorkItemStrategy)
      {
        case BoxAdaptiveMethodStategy.Simple:
          myQueue = new SimpleTaskQueue(settings.TaskLimit, myDim);
          break;
      }

      x = new double[myDim];
      y = new double[myDim];
      xleft = new double[myDim];
      xright = new double[myDim];
      overlapL = new double[myDim];
      overlapR = new double[myDim];
      myIterator = new BoxIterator<Divide>(myDim);

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

      myProcessor.AddPointWithOverlappingPrepare(per, overlapL, overlapR);
    }

    public void BuildImage(IntegerCoordinate coord)
    {
      mySystem.TopLeftPoint(coord, xleft);
      for (int i = 0; i < myDim; i++)
        xright[i] = xleft[i] + mySystem.CellSize[i];

      Point topPoint = Point.CreateTopLeft(myDim);
      Point bottomPoint = Point.CreateBottomRight(myDim);

      myQueue.Clear();
      myQueue.AddTask(null, new Pair<Point, Point>(topPoint, bottomPoint));

      while (myQueue.HasNextTask)
      {
        ProcessPoint(myQueue.NextTask(), myQueue);
      }
      myBuilder.ConnectToMany(coord, myPoints);


      foreach (Pair<double[], Point> pair in myQueue.NonProcessed)
      {
        myAdapter.AddPointWithOverlapping(coord, Evaluate(pair.Second), overlapL, overlapR);
      }

      foreach (Pair<double[], Point> work in myQueue.NonProcessed)
      {
        myAdapter.ConnectCellToPointWithRadius(coord, Evaluate(work.Second), work.First);
      }      
    }

    #endregion

    private double[] Evaluate(Point pt)
    {
      pt.Evaluate(xleft, xright, x);
      double[] result = new double[myDim];

      myFunction.Output = result;
      myFunction.Evaluate();

      return result;
    }

    private void AppendPoint(double[] d)
    {
      myPoints.AddRange(myProcessor.AddPointWithOverlappingInternal(d, overlapL, overlapR));
    }

    private void ProcessPoint(Pair<Point, Point> task, ISortedTaskQueue queue)
    {
      Point p1 = task.First;
      Point p2 = task.Second;

      double[] d1 = Evaluate(p1);
      double[] d2 = Evaluate(p2);

      double[] len = new double[myDim];
      bool result = true;
      for (int i = 0; i < myDim; i++)
      {
        double t = Math.Abs(d1[i] - d2[i]);
        len[i] = t;
        bool b = t <= eps[i];
        if (b)
        {
          div2[i] = Divide.First;
          divLeft[i] = Divide.Middle;
          divRight[i] = Divide.Middle;
        }
        else
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
        AppendPoint(d1);
        AppendPoint(d2);
      }
      else
      {
        foreach (Divide[] ts in myIterator.EnumerateBox(divLeft, divRight, div))
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