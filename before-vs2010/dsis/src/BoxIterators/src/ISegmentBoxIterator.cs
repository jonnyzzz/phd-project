using System.Collections.Generic;

namespace DSIS.BoxIterators
{
  public interface ISegmentBoxIterator<T>
  {
    IEnumerable<T[]> EnumerateSteps(T[] left, T[] right, T[] outs);    
  }
}