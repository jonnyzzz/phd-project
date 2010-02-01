/*
 * Created by: Eugene Petrenko
 * Created: 18 декабря 2006 г.
 */

using System;
using System.Collections.Generic;
using DSIS.BoxIterators;
using DSIS.BoxIterators.Generator;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilder.BoxMethod
{
  public class BoxMethod<Q> : IntegerCoordinateMethodBase<Q>, ICellImageBuilder<Q>
    where Q : IIntegerCoordinate
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
    private IRectProcessor<Q> myProcessor;

    

    private double[] myCellSize;
    private double[] myCellSizeHalf;

    public override void Bind(CellImageBuilderContext<Q> context)
    {
      base.Bind(context);
      myFunction = context.Function.GetFunction<double>(mySystem.CellSize);

      y = new double[myDim];
      x = new double[myDim];
      xLeft = new double[myDim];
      xRight = new double[myDim];
      yLeft = new double[myDim];
      yRight = new double[myDim];
      eps = new double[myDim];
      myIterator = BoxIteratorGenerator<double>.GenerateIterator(myDim);

      for (int i = 0; i < myDim; i++)
      {
        eps[i] = ((BoxMethodSettings) context.Settings).Eps*mySystem.CellSize[i];
      }

      myProcessor = mySystem.ProcessorFactory.CreateRectProcessor(eps);

      myCellSize = mySystem.CellSize;
      myCellSizeHalf = mySystem.CellSizeHalf;

      myFunction.Input = x;
      myFunction.Output = y;
    }

    public void BuildImage(Q coord)
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

      using (IEnumerator<double[]> cns = myIterator.EnumerateBox(xLeft, xRight, x).GetEnumerator())
      {
        while (cns.MoveNext())
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
      }

      myBuilder.ConnectToMany(coord, myProcessor.ConnectCellToRect(yLeft, yRight));
    }

    public ICellImageBuilder<Q> Clone()
    {
      return new BoxMethod<Q>();
    }
  }
}