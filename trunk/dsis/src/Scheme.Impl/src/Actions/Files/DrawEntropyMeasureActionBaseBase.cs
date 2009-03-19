using System;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class DrawEntropyMeasureActionBaseBase : IntegerCoordinateSystemActionBase2Ex
  {
    protected override void GetChecks<T, Q>(T system, Action<ContextMissmatchCheck> addCheck)
    {
      base.GetChecks<T,Q>(system, addCheck);
      if (system.Dimension != SystemDimension)
        throw new Exception("Dimension is assumend to be " + SystemDimension);

      addCheck(Create(FileKeys.WorkingFolderKey));
      addCheck(Create(Keys.GraphMeasure<Q>()));
    }

    public abstract int SystemDimension { get; }

    private static double Norm(IGraphMeasure measure)
    {
      return measure.CellSize.FoldLeft(1.0, (r,x)=>r*x);
    }

    protected GnuplotPointsFileWriter WriteMeasureFile<Q>(string measureFile, IGraphMeasure<Q> measure)
      where Q : IIntegerCoordinate
    {
      GnuplotPointsFileWriter wr;
      var data = new double[SystemDimension+1];
      var norm = Norm(measure);
      using (wr = new GnuplotPointsFileWriter(measureFile, SystemDimension + 1))
      {
        foreach (var pair in measure.GetMeasureNodes())
        {
          ((IIntegerCoordinateSystem<Q>)measure.CoordinateSystem).CenterPoint(pair.Key, data);
          data[SystemDimension] = pair.Value / norm;
          wr.WritePoint(new ImagePoint(data));
        }
      }
      return wr;
    }
  }
}