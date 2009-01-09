namespace DSIS.Scheme.Objects.Systemx
{
  public interface IOptionsBasedFactory<TOpts,R>
  {
    string FactoryName { get; }

    TOpts CreateOptions();

    /// <summary>
    /// Creates instance of <typeparamref name="R"/> using parameters specified 
    /// in object of type <typeparamref name="TOpts"/>
    /// </summary>
    /// <param name="options">parameters to the system.     
    /// <returns>new instance of <typeparamref name="R"/> according to parameters</returns>

    R Create(TOpts options);
  }
}