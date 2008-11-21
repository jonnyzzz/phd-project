using System;
using System.Collections.Generic;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

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
    
    protected GnuplotPointsFileWriter WriteMeasureFile<Q>(string measureFile, IGraphMeasure<Q> measure)
      where Q : IIntegerCoordinate
    {
      GnuplotPointsFileWriter wr;
      var data = new double[SystemDimension+1];
      using (wr = new GnuplotPointsFileWriter(measureFile, SystemDimension + 1))
      {
        foreach (var pair in measure.GetMeasureNodes())
        {
          ((IIntegerCoordinateSystem<Q>)measure.CoordinateSystem).CenterPoint(pair.Key, data);
          data[SystemDimension] = pair.Value;
          wr.WritePoint(new ImagePoint(data));
        }
      }
      return wr;
    }
  }
}