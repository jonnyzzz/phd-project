using System.Collections.Generic;
using DSIS.BoxIterators;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;

namespace DSIS.CellImageBuilders.PointMethod
{
  public class PointMethod<T, Q> : IntegerCoordinateMethodBase<T, Q>, ICellImageBuilder<Q>
    where T : IIntegerCoordinateSystem<Q>
    where Q : IIntegerCoordinate<Q>
  {
    private IPointProcessor<Q> myPointProcessor;
    private readonly List<Q> myPoints = new List<Q>();
    private double[] myDX;
    private double[] myDY;
    private double[] myDLeft;
    private double[] myDRight;
    private IFunction<double> myFunction;
    private DoubleLBoxIterator myIterator;

    public void BuildImage(Q coord)
    {
      mySystem.TopLeftPoint(coord, myDLeft);
      for (int i = 0; i < myDLeft.Length; i++)
        myDRight[i] = myDLeft[i] + mySystem.CellSize[i];

      using (IEnumerator<double[]> it = myIterator.EnumerateSteps(myDLeft, myDRight, myDX).GetEnumerator())
      {
        while (it.MoveNext())
        {
          myFunction.Evaluate();
          myPoints.AddRange(myPointProcessor.AddPoint(myDY));
        }
      }

      myBuilder.ConnectToMany(coord, myPoints);
      myPoints.Clear();
    }

    public override void Bind(CellImageBuilderContext<Q> context)
    {
      base.Bind(context);
      myDX = new double[myDim];
      myDY = new double[myDim];
      myDLeft = new double[myDim];
      myDRight = new double[myDim];

      myFunction = context.Function.GetFunction<double>();
      myFunction.Input = myDX;
      myFunction.Output = myDY;

      PointMethodSettings set = (PointMethodSettings) context.Settings;

      if (!set.UseOverlapping)
      {
        myPointProcessor = mySystem.ProcessorFactory.CreatePointProcessor();
      }
      else
      {
        myPointProcessor = mySystem.ProcessorFactory.CreateOverlapedPointProcessor(set.Overlap);
      }

      double[] dStep = new double[myDim];
      for (int i = 0; i < dStep.Length; i++)
      {
        dStep[i] = mySystem.CellSize[i]/(set.Points[i] - 1.0); //last point is right side
      }

      myIterator = new DoubleLBoxIterator(dStep);
    }

    public ICellImageBuilder<Q> Clone()
    {
      return new PointMethod<T, Q>();
    }

    public string PresentableName
    {
      get { return "PointMethod"; }
    }
  }
}