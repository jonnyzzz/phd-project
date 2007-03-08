namespace DSIS.BoxIterators
{
  public class LongLBoxIterator : SegmentBoxIterator<long>
  {
    public override void Inc(ref long t1)
    {
      t1++;
    }

    public override bool IsLower(long t1, long t2)
    {
      return t1 < t2;
    }
  }
}