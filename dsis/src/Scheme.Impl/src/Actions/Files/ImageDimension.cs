namespace DSIS.Scheme.Impl.Actions.Files
{
  public class ImageDimension
  {
    public static readonly Key<ImageDimension> KEY = new Key<ImageDimension>("");

    public int Width { get; set; }
    public int Height { get; set; }
  }
}