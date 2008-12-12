namespace DSIS.Scheme.Objects.Systemx
{
  public interface IOptionsBasedFactory<T,R>
  {
    string FactoryTitle { get; }
    string OptionsTitle { get; }

    T CreateOptions();

    R CreateFactory(T options);
  }
}