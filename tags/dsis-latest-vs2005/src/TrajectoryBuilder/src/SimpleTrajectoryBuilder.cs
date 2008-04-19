using System;
using DSIS.Core.System;

namespace DSIS.TrajectoryBuilder
{
  public class SimpleTrajectoryBuilder
  {    
    private readonly IFunction<double> myFunction;
    private double[] myOutput;

    private double[] myPoint;
    private readonly int myDimension;


    public SimpleTrajectoryBuilder(ISystemSpace space, ISystemInfo function, long precisionFactor)
    {      
      myDimension = space.Dimension;

      myPoint = new double[myDimension];
      myOutput = new double[myDimension];

      double[] precision = new double[myDimension];
      for(int i=0; i< myDimension; i++)
      {
        precision[i] = (space.AreaRightPoint[i] - space.AreaLeftPoint[i])/precisionFactor;
      }
      myFunction = function.GetFunction<double>(precision);

      Point = space.AreaLeftPoint;
    }

    public double[] Point
    {
      get { return myPoint; }
      set { Array.Copy(value, myPoint, myPoint.Length); }
    }

    public void Next()
    {
      myFunction.Input = myPoint;
      myFunction.Output = myOutput;
      myFunction.Evaluate();

      Swap(ref myPoint, ref myOutput);      
    }

    private static void Swap<T>(ref T t1, ref T t2)
    {
      T tmp = t1;
      t1 = t2;
      t2 = tmp;
    }
  }
}