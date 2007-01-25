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
      int[] steps = new int[dim + 1];
      for (int i = 0; i <= dim; i++)
      {
        steps[i] = 0;
      }

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

        steps[0]++;
        for (int i = 0; i < dim; i++)
        {
          if (steps[i] > 1)
          {
            steps[i] = 0;
            steps[i + 1]++;
          }
          else break;
        }
      }
    }
  }
}