using System;
using System.Drawing;
using DSIS.Graph.Images;
using DSIS.Scheme.Impl.Actions.Files;
using DSIS.SimpleRunner.Data;
using DSIS.Utils;

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

    public EntropyBuildParameters EntropyBuildParameters { get; set; }

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

                                 MeasureTimeout = MeasureTimeout,
                                 MeasureIterations = MeasureIterations,
                                 MeasurePrecision =  MeasurePrecision,

                                 GraphParameters = GraphParameters.Clone(),
                                 EntropyBuildParameters = EntropyBuildParameters.Clone(),
                               };
      imageEntropyData.CopyState(this);
      return imageEntropyData;
    }

    public override void Serialize(Logger log)
    {
      log.Write("Name:  {0}", Name);
      base.Serialize(log);            

      GraphParameters.Log(new PrefixLogger(log, "GraphParameters."));
      EntropyBuildParameters.Log(new PrefixLogger(log, "Entropy."));
      
      log.Write("Measure.Timeout: {0}", (object)MeasureTimeout ?? "Null");
      log.Write("Measure.Iterations: {0}", (object)MeasureIterations ?? "Null");
      log.Write("Measure.Precision: {0}", (object)MeasurePrecision ?? "Null");

    }
  }
}