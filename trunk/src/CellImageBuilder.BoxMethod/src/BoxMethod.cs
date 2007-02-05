/*
 * Created by: Eugene Petrenko
 * Created: 18 декабря 2006 г.
 */

using System.Collections.Generic;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;
using DSIS.Util;

namespace DSIS.CellImageBuilder
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
    private BoxIterator<double> myIterator;

    public override void Bind(CellImageBuilderContext<IntegerCoordinate> context)
    {
      base.Bind(context);
      myFunction = context.Function.GetFunction<double>();

      y = new double[myDim];
      x = new double[myDim];
      xLeft = new double[myDim];
      xRight = new double[myDim];
      eps = new double[myDim];
      myIterator = new BoxIterator<double>(myDim);
      
      for (int i = 0; i < myDim; i++)
      {
        eps[i] = ((BoxMethodParameters)context.Settings).Eps*mySystem.CellSize[i];
      }
      
      myFunction.Input = x;
      myFunction.Output = y;
    }

    public void BuildImage(IntegerCoordinate coord)
    {
      mySystem.TopLeftPoint(coord, xLeft);

      for (int i=0; i<myDim; i++)
      {
        x[i] = xLeft[i] + mySystem.CellSizeHalf[i];
        xRight[i] = xLeft[i] + mySystem.CellSize[i];
      }
      myFunction.Evaluate();

      yLeft = (double[]) y.Clone();
      yRight = (double[]) y.Clone();

      IEnumerable<double[]> cns = myIterator.EnumerateBox(xLeft, xRight, x);
      foreach (double[] cn in cns)
      {
        myFunction.Evaluate();
        for (int i=0; i<myDim; i++)
        {
          if (yLeft[i] > y[i])
            yLeft[i] = y[i];
          if (yRight[i] < y[i])
            yRight[i] = y[i];
        }
      }

      myAdapter.ConnectCellToRect(coord, yLeft, yRight, eps);
    }
  }
}