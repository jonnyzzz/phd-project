using DSIS.Scheme2.Nodes;

namespace DSIS.Scheme2.Graph
{
  public interface ISchemeGraphBuildContext
  {
    INode GetAction(string name);
    void RegisterInitializeAware(IInitializeAware aware);

    T GetUserData<T>(object host, string key, T def);
    void SetUserData<T>(object host, string key, T data);
  }
}