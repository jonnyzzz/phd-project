using System;
using System.Collections.Generic;
using DSIS.Core.Visualization;
using DSIS.GnuplotDrawer;
using DSIS.Graph.Entropy.Impl.Entropy;
using DSIS.IntegerCoordinates;
using DSIS.Scheme.Ctx;

namespace DSIS.Scheme.Impl.Actions.Files
{
  public abstract class DrawEntropyMeasureActionBaseBase : IntegerCoordinateSystemActionBase2
  {
    protected override ICollection<ContextMissmatchCheck> Check<T, Q>(T system, Context ctx)
    {
      if (system.Dimension != SystemDimension)
        throw new Exception("Dimension is assumend to be " + SystemDimension);

      return ColBase(base.Check<T, Q>(system, ctx),
                     Create(FileKeys.WorkingFolderKey),
                     Create(Keys.GraphMeasure<Q>()
                       ));
    }

    protected virtual int SystemDimension
    {
      get { return 2; }
    }

    protected GnuplotPointsFileWriter WriteMeasureFile<T, Q>(string measureFile, IGraphMeasure<Q> measure, T system)
      where Q : IIntegerCoordinate
      where T : IIntegerCoordinateSystem<Q>
    {
      GnuplotPointsFileWriter wr;
      var data = new double[SystemDimension+1];
      using (wr = new GnuplotPointsFileWriter(measureFile, SystemDimension + 1))
      {
        foreach (var pair in measure.GetMeasureNodes())
        {
          system.CenterPoint(pair.Key, data);
          data[SystemDimension] = pair.Value;
          wr.WritePoint(new ImagePoint(data));
        }
      }
      return wr;
    }
  }
}