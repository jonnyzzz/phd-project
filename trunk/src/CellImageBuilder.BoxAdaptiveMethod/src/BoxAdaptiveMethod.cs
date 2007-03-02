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
    private double[] myD1;
    private double[] myD2;

    private Divide[] divLeft;
    private Divide[] divMiddle;
    private Divide[] divRight;
    private Divide[] div;
    private Divide[] div2;

    private SimpleTaskQueue myQueue;
    private BoxIterator<Divide> myIterator;
    private OverlappingProcessor myProcessor;

    private List<IntegerCoordinate> myPoints = new List<IntegerCoordinate>(10000);

    #region ICellImageBuilder<IntegerCoordinate> Members

    public override void Bind(CellImageBuilderContext<IntegerCoordinate> context)
    {
      base.Bind(context);
      myProcessor = new OverlappingProcessor(mySystem);
      myFunction = context.Function.GetFunction<double>();

      BoxAdaptiveMethodSettings settings = (BoxAdaptiveMethodSettings) context.Settings;

      myQueue = new SimpleTaskQueue(settings.TaskLimit);

      x = new double[myDim];
      y = new double[myDim];
      myD1 = new double[myDim];
      myD2 = new double[myDim];
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
      myPoints.Clear();
      
      foreach (Point point in myQueue.Overlaped)
      {
        Evaluate(point, myD1);
        myAdapter.AddPointWithOverlapping(coord, myD1, overlapL, overlapR);
      }

      foreach (Pair<double[], Point> work in myQueue.NonProcessed)
      {
        Evaluate(work.Second, myD2);
        myAdapter.ConnectCellToPointWithRadius(coord, myD2, work.First);
      }      
    }

    public ICellImageBuilder<IntegerCoordinate> Clone()
    {
      return new BoxAdaptiveMethod();
    }

    #endregion

    private void Evaluate(Point pt, double[] output)
    {
      pt.Evaluate(xleft, xright, x);      

      myFunction.Output = output;
      myFunction.Evaluate();
    }

    private void AppendPoint(double[] d)
    {
      myPoints.AddRange(myProcessor.AddPointWithOverlappingInternal(d, overlapL, overlapR));
    }

    private void ProcessPoint(Pair<Point, Point> task, ISortedTaskQueue queue)
    {
      Point p1 = task.First;
      Point p2 = task.Second;

      Evaluate(p1, myD1);
      Evaluate(p2, myD2);

      double[] len = new double[myDim];
      bool result = true;
      for (int i = 0; i < myDim; i++)
      {
        double t = Math.Abs(myD1[i] - myD2[i]);
        len[i] = t;
        bool b = t <= eps[i];
        result &= b;

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
        
      }
      if (result)
      {
        AppendPoint(myD1);
        AppendPoint(myD2);
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