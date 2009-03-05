using System.Collections.Generic;

namespace DSIS.BoxIterators
{
  public interface ISegmentBoxIterator<T>
  {
    IEnumerable<T[]> EnumerateSteps(T[] left, T[] right, T[] outs);    
  }

  public abstract class SegmentBoxIterator<T> : ISegmentBoxIterator<T>
  {
    protected abstract void Inc(int index, ref T t1);
    protected abstract bool IsLower(int index, T t1, T t2);

    public IEnumerable<T[]> EnumerateSteps(T[] left, T[] right, T[] outs)
    {
      int dim = left.Length;
      for (int i = 0; i < dim; i++)
        outs[i] = left[i];
      
      yield return outs;

      while (true)
      {
        Inc(0, ref outs[0]);

        for (int i = 0; i < dim; i++)
        {
          if (IsLower(i, outs[i], right[i]))
            continue;

          outs[i] = left[i];
          if (i + 1 < dim)
            Inc(i + 1, ref outs[i + 1]);
          else
            yield break;
        }

        yield return outs;
      }
    }
  }
}