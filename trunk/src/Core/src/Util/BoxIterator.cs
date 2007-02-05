using System.Collections.Generic;

namespace DSIS.Util
{
  public class BoxIterator<T>
  {
    private readonly int myDim;
    private readonly int[] steps;
    private readonly bool[] skips;


    public BoxIterator(int dim)
    {
      myDim = dim;
      steps = new int[dim + 1];
      skips = new bool[dim + 1];
    }

    /// <summary>
    /// Every time outs array is returned. But values differs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="outs"></param>
    /// <returns></returns>
    public IEnumerable<T[]> EnumerateBox(T[] left, T[] right, T[] outs)
    {
      int inc = 0;
      for (int i = myDim - 1; i >=0 ; i--)
      {
        steps[i] = 0;
        skips[i] = left[i].Equals(right[i]);
        inc = skips[i] ? inc : i;
      }
      steps[myDim] = 0;
      skips[myDim] = false;
      

      while (steps[myDim] == 0)
      {
        for (int i = 0; i < myDim; i++)
        {
          if (steps[i] == 0)
          {
            outs[i] = left[i];
          }
          else
          {
            outs[i] = right[i];
          }
        }

        yield return outs;

        steps[inc]++;
        for (int i = inc; i < myDim; i++)
        {
          if (steps[i] > 1)
          {
            steps[i] = 0;
            steps[++i]++;
            while( i+1 < myDim && skips[i + 1])
              steps[i++ + 1]++;
            i--;
          }
          else break;
        }
      }
    }
  }
}