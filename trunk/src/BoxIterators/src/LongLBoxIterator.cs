namespace DSIS.BoxIterators
{
  public sealed class LongLBoxIterator : SegmentBoxIterator<long>
  {
    public override void Inc(int index, ref long t1)
    {
      t1++;
    }

    public override bool IsLower(int index, long t1, long t2)
    {
      return t1 < t2;
    }
  }
}