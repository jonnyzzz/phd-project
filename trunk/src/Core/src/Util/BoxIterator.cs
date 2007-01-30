using System.Collections.Generic;

namespace DSIS.Util
{
  public static class BoxIterator
  {
    /// <summary>
    /// Every time outs array is returned. But values differs
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <param name="outs"></param>
    /// <returns></returns>
    public static IEnumerable<T[]> EnumerateBox<T>(T[] left, T[] right, T[] outs)
    {
      int dim = left.Length;
      //todo: Move array creations to instance!
      int[] steps = new int[dim + 1];
      bool[] skips = new bool[dim+1];
      int inc = 0;
      for (int i = dim - 1; i >=0 ; i--)
      {
        steps[i] = 0;
        skips[i] = left[i].Equals(right[i]);
        inc = skips[i] ? inc : i;
      }
      steps[dim] = 0;
      skips[dim] = false;
      

      while (steps[dim] == 0)
      {
        for (int i = 0; i < dim; i++)
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
        for (int i = inc; i < dim; i++)
        {
          if (steps[i] > 1)
          {
            steps[i] = 0;
            steps[++i]++;
            while( i+1 < dim && skips[i + 1])
              steps[i++ + 1]++;
            i--;
          }
          else break;
        }
      }
    }
  }
}