namespace DSIS.Utils
{
  public interface ICloneable<out T>
  {
    T Clone();
  }
}