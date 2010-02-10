namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawEntropyMeasureWithBaseAction : DrawEntropyMeasureWithBaseActionBase
  {
    public DrawEntropyMeasureWithBaseAction() :
      base(new DrawEntropyMeasureActionBase[]
             {
               new DrawEntropyMeasure2dWithBaseAction(),
               new DrawEntropyMeasure3dWithBaseAction()
             })
    {
    }
  }
}