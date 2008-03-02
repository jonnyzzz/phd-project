namespace DSIS.Scheme2.XmlModel
{
  public interface IInitializeAware
  {
    void Initialized();
  }

  public delegate void InitializedDelegate();
}