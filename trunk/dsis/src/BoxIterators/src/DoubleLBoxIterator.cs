using System;
using System.Collections.Generic;

namespace DSIS.BoxIterators
{
  public sealed class DoubleLBoxIterator : ISegmentBoxIterator<double>
  {
    private readonly int[] myZero;
    private readonly int[] myTmp;
    private readonly int[] mySub;
    private readonly double[] mySteps;

    public DoubleLBoxIterator(double[] eps, int[] sub)
    {
      mySteps = new double[eps.Length];
      mySub = (int[]) sub.Clone();
      myZero = new int[eps.Length];
      myTmp = new int[eps.Length];

      for (int i = 0; i < eps.Length; i++)
      {
        var subd = sub[i] - 1;
        var epsd = eps[i];
        var x = epsd/subd;
        //Necessary to make x * subd < eps. This may not be so without that trick.
        x -= Math.Abs(epsd - x*subd);

        mySteps[i] = x;
        myZero[i] = 0;
        myTmp[i] = 0;
      }
    }

    public IEnumerable<double[]> EnumerateSteps(double[] left, double[] right, double[] outs)
    {
      foreach (var _ in new DoubleIntLBoxIterator(left, mySteps, outs).EnumerateSteps(myZero, mySub, myTmp))
      {
        yield return outs;
      }
    }

    private class DoubleIntLBoxIterator : SegmentBoxIterator<int>
    {
      private readonly double[] myLeft;
      private readonly double[] myDEps;
      private readonly double[] myDValue;

      public DoubleIntLBoxIterator(double[] left, double[] dEps, double[] dValue)
      {
        myLeft = left;
        myDEps = dEps;
        myDValue = dValue;
      }

      protected override void Reset(int index, ref int data, int value)
      {
        base.Reset(index, ref data, value);
        myDValue[index] = myLeft[index];
      }

      protected override void Inc(int index, ref int t1)
      {
        myDValue[index] += myDEps[index];
        t1 += 1;
      }

      protected override bool IsLower(int index, int t1, int t2)
      {
        return t1 < t2;
      }
    }
  }
}