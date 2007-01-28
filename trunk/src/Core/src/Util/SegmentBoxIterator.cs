using System.Collections.Generic;

namespace DSIS.Util
{
  public abstract class SegmentBoxIterator<T>
  {
    public abstract void Inc(ref T t1);
    public abstract bool IsLower(T t1, T t2);

    public IEnumerable<T[]> EnumerateSteps(T[] left, T[] right, T[] outs)
    {
      int dim = left.Length;
      for (int i = 0; i < dim; i++)
        outs[i] = left[i];

      bool isWorking = true;
      while (isWorking)
      {
        yield return outs;

        Inc(ref outs[0]);

        for (int i = 0; i < dim; i++)
        {
          if (!IsLower(outs[i], right[i]))
          {
            outs[i] = left[i];
            if (i + 1 < dim)
              Inc(ref outs[i + 1]);
            else
              isWorking = false;
          }
          else break;
        }
      }
    }
  }
}