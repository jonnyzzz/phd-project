using System.Drawing;
using DSIS.Graph.Images;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner
{
  public class ImageEntropyData : BuilderDataBase, ICloneable<ImageEntropyData>
  {
    public Bitmap Image { get; set; }

    public GraphFromImageBuilderParameters GraphParameters { get; set; }

    ImageEntropyData ICloneable<ImageEntropyData>.Clone()
    {
      var imageEntropyData = new ImageEntropyData{ Image = Image, GraphParameters = GraphParameters};
      imageEntropyData.CopyState(this);
      return imageEntropyData;
    }

    public override void Serialize(Logger log)
    {
      base.Serialize(log);
      log.Write("Parameters.Hash: {0}", GraphParameters.Hash);
      log.Write("Parameters.Threahold: {0}", GraphParameters.Threasold);
      log.Write("Parameters.NumberOfEdgesPerPixel: {0}", GraphParameters.NumberOfEdgesPerPixel);
      log.Write("Parameters.NumberOfNeighboursPerAxis: {0}", GraphParameters.NumberOfNeighboursPerAxis);
    }
  }
}