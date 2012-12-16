using System;
using System.Drawing;
using DSIS.Graph.Images;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner.ImageEntropy
{
  public class ImageEntropyData : BuilderDataBase, ICloneable<ImageEntropyData>
  {
    public string Name { get; set; }
    public Bitmap Image { get; set; }
    public Color RenderMinColor { get; set; }
    public Color RenderMaxColor { get; set; }

    public TimeSpan? MeasureTimeout { get; set; }
    public int? MeasureIterations { get; set; }
    public double? MeasurePrecision { get; set; }

    public GraphFromImageBuilderParameters GraphParameters { get; set; }

    public int? ForkJoinImageSize { get; set; }

    public ImageEntropyData()
    {
      RenderMinColor = Color.White;
      RenderMaxColor = Color.MediumSeaGreen;
    }

    public ImageEntropyData CloneData()
    {
      return ((ICloneable<ImageEntropyData>) this).Clone();
    }

    ImageEntropyData ICloneable<ImageEntropyData>.Clone()
    {
      var imageEntropyData = new ImageEntropyData
                               {
                                 Name = Name,
                                 Image = Image, 
                                 RenderMinColor = RenderMinColor,
                                 RenderMaxColor = RenderMaxColor,

                                 ForkJoinImageSize = ForkJoinImageSize,

                                 MeasureTimeout = MeasureTimeout,
                                 MeasureIterations = MeasureIterations,
                                 MeasurePrecision =  MeasurePrecision,

                                 GraphParameters = GraphParameters,
                               };
      imageEntropyData.CopyState(this);
      return imageEntropyData;
    }

    public override void Serialize(Logger log)
    {
      log.Write("Name:  {0}", Name);
      base.Serialize(log);            
      log.Write("Parameters.Hash: {0}", GraphParameters.Hash);
      log.Write("Parameters.NumberOfNeighboursPerAxis: {0}", GraphParameters.NumberOfNeighboursPerAxis);
      log.Write("Measure.Timeout: {0}", (object)MeasureTimeout ?? "Null");
      log.Write("Measure.Iterations: {0}", (object)MeasureIterations ?? "Null");
      log.Write("Measure.Precision: {0}", (object)MeasurePrecision ?? "Null");
      var cp = GraphParameters as ComplexGraphFromImageBuilderParameters;
      if (cp != null)
      {
        log.Write("Parameters.Threahold: {0}", cp.Threasold);
        log.Write("Parameters.NumberOfEdgesPerPixel: {0}", cp.NumberOfEdgesPerPixel);
      }      
    }
  }
}