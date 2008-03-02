namespace DSIS.Scheme2.XmlModel
{
  public interface ISchemeGraphBuildContext
  {
    INode GetAction(string name);
    void RegisterInitializeAware(IInitializeAware aware);

    T GetUserData<T>(object host, string key, T def);
    void SetUserData<T>(object host, string key, T data);
  }
}