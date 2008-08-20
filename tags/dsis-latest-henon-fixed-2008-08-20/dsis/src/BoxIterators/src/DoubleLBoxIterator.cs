namespace DSIS.BoxIterators
{
  public sealed class DoubleLBoxIterator : SegmentBoxIterator<double>
  {
    private readonly double[] mySteps;

    public DoubleLBoxIterator(double[] steps)
    {
      mySteps = steps;
    }

    protected override void Inc(int i, ref double t1)
    {
      t1 += mySteps[i];
    }

    protected override bool IsLower(int i, double t1, double t2)
    {
      return t1 <= t2;
    }
  }
}