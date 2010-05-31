namespace DSIS.UI.ComputationDialogs.Constraints
{
  [SIConstructionComponent]
  public class RepeatCountTool : RepeatWhileControlBase
  {
    public RepeatCountTool() : base("Repeat", "times")
    {
    }

    public override string SortName
    {
      get { return "1000"; }
    }

    protected override ISIComputationConstraint CreateConstraint(long count)
    {
      return new RepeatCountToolConstraint(count);
    }
  }
}