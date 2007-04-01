/*
 * Created by: Eugene Petrenko
 * Created: 18 декабря 2006 г.
 */

using System;
using System.Collections.Generic;
using DSIS.BoxIterators;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.BoxMethod
{
  public class BoxMethod : IntegerCoordinateMethodBase, ICellImageBuilder<IntegerCoordinate>
  {
    private IFunction<double> myFunction;
    private double[] x;
    private double[] xLeft;
    private double[] xRight;
    private double[] yLeft;
    private double[] yRight;
    private double[] y;
    private double[] eps;
    private IBoxIterator<double> myIterator;

    private double[] myCellSize;
    private double[] myCellSizeHalf;

    public override void Bind(CellImageBuilderContext<IntegerCoordinate> context)
    {
      base.Bind(context);
      myFunction = context.Function.GetFunction<double>();

      y = new double[myDim];
      x = new double[myDim];
      xLeft = new double[myDim];
      xRight = new double[myDim];
      yLeft = new double[myDim];
      yRight = new double[myDim];      
      eps = new double[myDim];
      myIterator = new BoxIterator<double>(myDim);

      for (int i = 0; i < myDim; i++)
      {
        eps[i] = ((BoxMethodSettings) context.Settings).Eps*mySystem.CellSize[i];
      }

      myCellSize = mySystem.CellSize;
      myCellSizeHalf = mySystem.CellSizeHalf;

      myFunction.Input = x;
      myFunction.Output = y;
    }

    public void BuildImage(IntegerCoordinate coord)
    {
      mySystem.TopLeftPoint(coord, xLeft);

      for (int i = 0; i < myDim; i++)
      {
        x[i] = xLeft[i] + myCellSizeHalf[i];
        xRight[i] = xLeft[i] + myCellSize[i];
      }
      myFunction.Evaluate();

      Array.Copy(y, yLeft, myDim);
      Array.Copy(y, yRight, myDim);
      
      IEnumerable<double[]> cns = myIterator.EnumerateBox(xLeft, xRight, x);
      foreach (double[] _ in cns)
      {
        myFunction.Evaluate();
        for (int i = 0; i < myDim; i++)
        {
          if (yLeft[i] > y[i])
            yLeft[i] = y[i];
          if (yRight[i] < y[i])
            yRight[i] = y[i];
        }
      }

      myAdapter.ConnectCellToRect(coord, yLeft, yRight, eps);
    }

    public ICellImageBuilder<IntegerCoordinate> Clone()
    {
      return new BoxMethod();
    }
  }
}