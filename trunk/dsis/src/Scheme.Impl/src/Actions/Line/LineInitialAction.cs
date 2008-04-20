using System.Collections.Generic;
using DSIS.LineIterator;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Line
{
  public class LineInitialAction : ActionBase
  {
    private readonly double myEps;
    private readonly double[] myLeft;
    private readonly double[] myRight;

    public LineInitialAction(double eps, double[] left, double[] right)
    {
      myEps = eps;
      myLeft = left;
      myRight = right;
    }

    public override ICollection<ContextMissmatch> Compatible(Context ctx)
    {
      return CheckContext(ctx);
    }

    protected override void Apply(Context ctx, Context result)
    {            
      var line = LineFactory.CreateInitialLine(myEps, myLeft, myRight);
      
      Keys.LineKey.Set(result, line);     
    }    
  }
}