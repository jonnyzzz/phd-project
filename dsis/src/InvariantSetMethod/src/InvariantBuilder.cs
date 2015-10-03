using DSIS.CellImageBuilder.Shared;
using DSIS.Core.Builders;
using DSIS.IntegerCoordinates;
using DSIS.InvatriantSetMethod.src;

namespace DSIS.InvatriantSetMethod
{
  public class InvariantBuilder<Q> : IntegerCoordinateMethodBase<Q>, ICellImageBuilder<Q> 
    where Q : IIntegerCoordinate
  {
    private InvariantBuilderSettings mySettings;
    private IteratingFunction2 myIteratingFunction;

    public override void Bind(CellImageBuilderContext<Q> context)
    {
      base.Bind(context);
      mySettings = (InvariantBuilderSettings) context.Settings;
      myIteratingFunction = new IteratingFunction2(()=>context.Function.GetFunction<double>(0));
    }

    public void BuildImage(Q coord)
    {
      mySystem.CenterPoint(coord, myIteratingFunction.Value);
      for(int i=0; i<mySettings.NumberOfIterations/2+1; i++)
      {
        myIteratingFunction.EvaluatePair();
        if (!mySystem.SystemSpace.Contains(myIteratingFunction.Value))
          return;
      }

      myBuilder.ConnectToOne(coord, coord);
    }

    public ICellImageBuilder<Q> Clone()
    {
      return new InvariantBuilder<Q>();
    }

    public string PresentableName
    {
      get { return "Invariant set"; }
    }
  }
}