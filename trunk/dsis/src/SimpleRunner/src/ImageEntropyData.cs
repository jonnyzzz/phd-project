using System.Drawing;
using DSIS.Graph.Images;

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
  }
}