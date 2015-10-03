using System;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.BoxMethod.Angle2D
{
  public class BoxMethodAngle2D<Q> : IntegerCoordinateMethodBase<Q>, ICellImageBuilder<Q>
    where Q : IIntegerCoordinate
  {
    private IFunction<double> myFunctionX;
    private IFunction<double> myFunctionLX;
    private IFunction<double> myFunctionRX;

    private double[] myX;
    private double[] myLX;
    private double[] myRX;

    private double[] myOX;
    private double[] myOLX;
    private double[] myORX;

    private IRectProcessor<Q> myProcessor;

    
    public override void Bind(CellImageBuilderContext<Q> context)
    {
      var dimension = context.Function.Dimension;
      if (dimension != 1)
        throw new Exception("Only Dimension=1 is supported");

      myProcessor = mySystem.ProcessorFactory.CreateRectProcessor(mySystem.CellSizeHalf);

      myFunctionX = context.Function.GetFunction(mySystem.CellSize);
      myFunctionLX = context.Function.GetFunction(mySystem.CellSize);
      myFunctionRX = context.Function.GetFunction(mySystem.CellSize);

      myX = new double[dimension];
      myLX = new double[dimension];
      myRX = new double[dimension];
      myOX = new double[dimension];
      myOLX = new double[dimension];
      myORX = new double[dimension];

      myFunctionX.Input = myX;
      myFunctionLX.Input = myLX;
      myFunctionRX.Input = myRX;

      myFunctionX.Output = myOX;
      myFunctionLX.Output = myOLX;
      myFunctionRX.Output = myORX;
    }

    public void BuildImage(Q coord)
    {
      mySystem.TopLeftPoint(coord, myLX);

      myX[0] = myLX[0] + mySystem.CellSizeHalf[0];
      myRX[0] = myX[0] + mySystem.CellSizeHalf[0];

      myFunctionX.Evaluate();
      myFunctionLX.Evaluate();
      myFunctionRX.Evaluate();

      if (myOLX[0] > myORX[0])
        Swap(ref myOLX[0], ref myORX[0]);

      if (myOLX[0] <= myOX[0] && myOX[0] <= myORX[0])
      {
        myBuilder.ConnectToMany(coord, myProcessor.ConnectCellToRect(myOLX, myORX));
      } else
      {
        myBuilder.ConnectToMany(coord, 
          myProcessor.ConnectCellToRect(mySystem.SystemSpace.AreaLeftPoint, myOLX).Join(myProcessor.ConnectCellToRect(myORX, mySystem.SystemSpace.AreaRightPoint)));
      }
    }

    private static void Swap<T>(ref T r1, ref T r2)
    {
      T t = r1;
      r1 = r2;
      r2 = t;
    }

    public ICellImageBuilder<Q> Clone()
    {
      return new BoxMethodAngle2D<Q>();
    }
  }
}
