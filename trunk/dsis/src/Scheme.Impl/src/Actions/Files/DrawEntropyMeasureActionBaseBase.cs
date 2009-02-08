using System;
using System.Collections.Generic;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;
using DSIS.Utils;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class DrawEntropyMeasureActionBaseBase : IntegerCoordinateSystemActionBase3
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(Context ctx)
    {
      if (Dimension != SystemDimension)
        throw new Exception("Dimension is assumend to be " + SystemDimension);

      return ColBase(base.Check<T, Q>(ctx),
                     Create(FileKeys.WorkingFolderKey),
                     Create(Keys.GraphMeasure<Q>()
                       ));
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