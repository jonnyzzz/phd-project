using System;
using System.Collections.Generic;
using DSIS.BoxIterators;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.Core.Util;
using DSIS.IntegerCoordinates;

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
    private double[] myLen;

    private Divide[] divLeft;
    private Divide[] divMiddle;
    private Divide[] divRight;
    private Divide[] div;
    private Divide[] div2;

    private BoxIterator<Divide> myIterator;

    private OverlappingProcessor myOverlappingProcessor;
    private RadiusProcessor myRadiusProcessor;

    private Queue<Pair<Point, Point>> myQueue = new Queue<Pair<Point, Point>>();
    private List<IntegerCoordinate> myPoints = new List<IntegerCoordinate>(10000);
    
    private int myLimit;
    private int myProcessed;
    private double myAddRadiusFactor;

    public override void Bind(CellImageBuilderContext<IntegerCoordinate> context)
    {
      base.Bind(context);
      myOverlappingProcessor = new OverlappingProcessor(mySystem);
      myRadiusProcessor = new RadiusProcessor(mySystem);

      myFunction = context.Function.GetFunction<double>();

      BoxAdaptiveMethodSettings settings = (BoxAdaptiveMethodSettings) context.Settings;

      myLimit = settings.TaskLimit;
      myProcessed = 0;
      myAddRadiusFactor = settings.AddRadiusFactor;

      myQueue.Clear();
      
      x = new double[myDim];
      y = new double[myDim];
      myD1 = new double[myDim];
      myD2 = new double[myDim];
      xleft = new double[myDim];
      xright = new double[myDim];
      overlapL = new double[myDim];
      overlapR = new double[myDim];
      myLen = new double[myDim];
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
      
      myOverlappingProcessor.AddPointWithOverlappingPrepare(per, overlapL, overlapR);
    }

    public void BuildImage(IntegerCoordinate coord)
    {
      myProcessed = 0;

      mySystem.TopLeftPoint(coord, xleft);
      for (int i = 0; i < myDim; i++)
        xright[i] = xleft[i] + mySystem.CellSize[i];

      Point topPoint = Point.CreateTopLeft(myDim);
      Point bottomPoint = Point.CreateBottomRight(myDim);

      myQueue.Enqueue(new Pair<Point, Point>(topPoint, bottomPoint));

      while (myQueue.Count > 0)
      {
        ProcessPoint(myQueue.Dequeue());
      }

      myBuilder.ConnectToMany(coord, myPoints);
      myPoints.Clear();
      myQueue.Clear();
    }

    public ICellImageBuilder<IntegerCoordinate> Clone()
    {
      return new BoxAdaptiveMethod();
    }

    private void Evaluate(Point pt, double[] output)
    {
      pt.Evaluate(xleft, xright, x);      

      myFunction.Output = output;
      myFunction.Evaluate();
    }

    private void AppendPoint(double[] d)
    {
      
      myPoints.AddRange(myOverlappingProcessor.AddPointWithOverlappingInternal(d, overlapL, overlapR));
    }

    private void ProcessPoint(Pair<Point, Point> task)
    {
      Point p1 = task.First;
      Point p2 = task.Second;

      Evaluate(p1, myD1);
      Evaluate(p2, myD2);

      bool result = true;
      for (int i = 0; i < myDim; i++)
      {
        double t = Math.Abs(myD1[i] - myD2[i]);
        myLen[i] = t * myAddRadiusFactor;
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
        myProcessed += 2;

        AppendPoint(myD1);
        AppendPoint(myD2);
      }
      else
      {
        if (myProcessed < myLimit)
        {
          foreach (Divide[] ts in myIterator.EnumerateBoxChecked(divLeft, divRight, div))
          {
            for (int i = 0; i < myDim; i++)
            {
              if (div2[i] != Divide.Middle)
                div2[i] = ts[i] == Divide.First ? Divide.Second : Divide.First;
            }
            myQueue.Enqueue(new Pair<Point, Point>(
                              Point.Middle(p1, p2, div2),
                              Point.Middle(p1, p2, ts)
                              )
              );
          }
        }
        else
        {
          myPoints.AddRange(myRadiusProcessor.ConnectCellToRectInternal(myD1, myLen));
          myPoints.AddRange(myRadiusProcessor.ConnectCellToRectInternal(myD2, myLen));
        }
      }
    }
  }
}