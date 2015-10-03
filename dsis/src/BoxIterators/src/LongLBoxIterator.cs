namespace DSIS.BoxIterators
{
  public sealed class LongLBoxIterator : SegmentBoxIterator<long>
  {
    protected override void Inc(int index, ref long t1)
    {
      t1++;
    }

    protected override bool IsLower(int index, long t1, long t2)
    {
      return t1 < t2;
    }
  }
}