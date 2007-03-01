using DSIS.Core.Util;

namespace DSIS.Util
{
  internal class IntLBoxIterator : SegmentBoxIterator<int>
  {
    public override void Inc(ref int t1)
    {
      t1++;
    }

    public override bool IsLower(int t1, int t2)
    {
      return t1 < t2;
    }
  }
}