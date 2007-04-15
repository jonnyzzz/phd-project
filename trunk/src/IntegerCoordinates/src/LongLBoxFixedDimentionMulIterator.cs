using System.Collections.Generic;
using DSIS.BoxIterators;

namespace DSIS.IntegerCoordinates
{
  /// <summary>
  /// This class cann't be used in multithread context!
  /// </summary>
  internal class LongLBoxFixedDimentionMulIterator
  {
    private long[] myTmp;
    private long[] myOuts;
    private long[] myMuls;
    private LongLBoxIterator myIt = new LongLBoxIterator();

    public LongLBoxFixedDimentionMulIterator(int dim)
    {
      myTmp = new long[dim];
      myOuts = new long[dim];
      myMuls = new long[dim];
    }

    public IEnumerable<long[]> Iterate(long[] left, long[] d)
    {
      for (int i = 0; i < d.Length; i++)
      {
        myMuls[i] = left[i]*d[i];
        myTmp[i] = myMuls[i] + d[i];
      }

      return myIt.EnumerateSteps(myMuls, myTmp, myOuts);
    }
  }
}