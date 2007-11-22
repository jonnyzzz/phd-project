namespace DSIS.Scheme
{
  internal interface IKey
  {
    string Name { get; }
  }

  public class Key<TValue> : IKey
  {
    private readonly string myName;

    public Key(string name)
    {
      myName = name;
    }

    public string Name
    {
      get { return typeof(TValue).FullName + "|" + myName; }
    }
  }
}