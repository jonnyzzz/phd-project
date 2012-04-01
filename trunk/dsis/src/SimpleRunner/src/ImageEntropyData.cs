using System.Drawing;
using DSIS.Graph.Images;
using DSIS.Scheme.Impl.Actions.Files;

namespace DSIS.SimpleRunner
{
  public class ImageEntropyData : BuilderDataBase, ICloneable<ImageEntropyData>
  {
    public string Name { get; set; }
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
      log.Write("Name:  {0}", Name);
      base.Serialize(log);            
      log.Write("Parameters.Hash: {0}", GraphParameters.Hash);
      log.Write("Parameters.NumberOfNeighboursPerAxis: {0}", GraphParameters.NumberOfNeighboursPerAxis);
      var cp = GraphParameters as ComplexGraphFromImageBuilderParameters;
      if (cp != null)
      {
        log.Write("Parameters.Threahold: {0}", cp.Threasold);
        log.Write("Parameters.NumberOfEdgesPerPixel: {0}", cp.NumberOfEdgesPerPixel);
      }      
    }
  }
}