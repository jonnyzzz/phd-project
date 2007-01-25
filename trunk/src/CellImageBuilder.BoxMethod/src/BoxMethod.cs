/*
 * Created by: Eugene Petrenko
 * Created: 18 декабря 2006 г.
 */

using System.Collections.Generic;
using DSIS.Core.Coordinates;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;
using DSIS.Util;

namespace DSIS.CellImageBuilder
{
  public class BoxMethod : ICellImageBuilder<IntegerCoordinate>
  {
    private IIntegerCoordinateSystem mySystem;
    private ICellConnectionBuilder<IntegerCoordinate> myBuilder;
    private IIntegerCoordinateCellImageBuilderAdapter myAdapter;

    private IFunction<double> myFunction;
    private double[] x;
    private double[] xLeft;
    private double[] xRight;    
    private double[] yLeft;
    private double[] yRight;
    private double[] y;
    private double[] eps;

    private int myDim;

    public void Bind(CellImageBuilderContext<IntegerCoordinate> context)
    {
      mySystem = (IIntegerCoordinateSystem) context.System;
      myBuilder = context.ConnectionBuilder;
      myFunction = context.Function.GetFunction<double>(1);
      myAdapter = mySystem.CreateAdapter(myBuilder);
      myDim = context.System.SystemSpace.Dimension;

      y = new double[myDim];
      x = new double[myDim];
      xLeft = new double[myDim];
      xRight = new double[myDim];
      eps = new double[myDim];
      
      //todo: This paramater could be sent to the method
      for (int i = 0; i < myDim; i++)
      {
        eps[i] = 0.1*mySystem.CellSize[i];
      }
      
      myFunction.Input = x;
      myFunction.Output = y;
    }

    public void BuildImage(IntegerCoordinate coordinate)
    {
      mySystem.TopLeftPoint(coordinate, xLeft);

      for (int i=0; i<myDim; i++)
      {
        x[i] = xLeft[i] + mySystem.CellSizeHalf[i];
        xRight[i] = xLeft[i] + mySystem.CellSize[i];
      }
      myFunction.Evaluate();

      yLeft = (double[]) y.Clone();
      yRight = (double[]) y.Clone();

      IEnumerable<double[]> cns = BoxIterator.EnumerateBox(xLeft, xRight, x);
      foreach (double[] cn in cns)
      {
        myFunction.Evaluate();
        for (int i=0; i<myDim; i++)
        {
          if (yLeft[i] > cn[i])
            yLeft[i] = cn[i];
          if (yRight[i] < cn[i])
            yRight[i] = cn[i];
        }
      }

      myAdapter.ConnectCellToRect(coordinate, yLeft, yRight, eps);
    }
  }
}