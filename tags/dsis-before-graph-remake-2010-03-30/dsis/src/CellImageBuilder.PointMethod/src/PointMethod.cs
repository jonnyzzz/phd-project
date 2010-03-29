using System.Collections.Generic;
using DSIS.BoxIterators;
using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.Core.System;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.CellImageBuilder.PointMethod
{
  public class PointMethod<Q> : IntegerCoordinateMethodBase<Q>, ICellImageBuilder<Q>    
    where Q : IIntegerCoordinate
  {
    private IPointProcessor<Q> myPointProcessor;
    private double[] myDX;
    private double[] myDY;
    private double[] myDLeft;
    private double[] myDRight;
    private IFunction<double> myFunction;
    private DoubleLBoxIterator myIterator;

    public void BuildImage(Q coord)
    {
      myBuilder.ConnectToMany(coord, BuildImageInternal(coord));
    }

    private IEnumerable<Q> BuildImageInternal(Q coord)
    {
      mySystem.TopLeftPoint(coord, myDLeft);
      for (int i = 0; i < myDim; i++)
        myDRight[i] = myDLeft[i] + mySystem.CellSize[i];

      using (var it = myIterator.EnumerateSteps(myDLeft, myDRight, myDX).GetEnumerator())
      {
        while (it.MoveNext())
        {
          myFunction.Evaluate();
          foreach (Q q in myPointProcessor.AddPoint(myDY))
          {
            yield return q;
          }          
        }
      }      
    }

    public override void Bind(CellImageBuilderContext<Q> context)
    {
      base.Bind(context);
      myDX = new double[myDim];
      myDY = new double[myDim];
      myDLeft = new double[myDim];
      myDRight = new double[myDim];

      myFunction = context.Function.GetFunction(mySystem.CellSize);
      myFunction.Input = myDX;
      myFunction.Output = myDY;

      var set = (PointMethodSettings) context.Settings;

      myPointProcessor = set.UseOverlapping 
        ? mySystem.ProcessorFactory.CreateOverlapedPointProcessor(set.Overlap) 
        : mySystem.ProcessorFactory.CreatePointProcessor();

      myIterator = new DoubleLBoxIterator(mySystem.CellSize, set.Points.Fill(mySystem.Dimension));
    }

    public ICellImageBuilder<Q> Clone()
    {
      return new PointMethod<Q>();
    }
  }
}