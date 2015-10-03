using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public class DrawEntropyMeasureColorMapAction : DrawEntropyMeasureActionBaseBase
  {
    protected override void Apply<T, Q>(T system, Context input, Context output)
    {
      WorkingFolderInfo info = FileKeys.WorkingFolderKey.Get(input);
      IGraphMeasure<Q> measure = Keys.GraphMeasure<Q>().Get(input);

      EntropyDrawColorMapHelper.RenderMeasure(info, measure, (key, pts)=>((IIntegerCoordinateSystem<Q>)measure.CoordinateSystem).CenterPoint(key, pts));
    }

    public override int SystemDimension
    {
      get { return 2; }
    }
  }
}