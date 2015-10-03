using System.Collections.Generic;

namespace DSIS.Scheme.Xml
{
  public class Bag
  {
    private readonly Bag myParent;
    private readonly IDictionary<string, object> myBag = new Dictionary<string, object>();

    public Bag() : this(null)
    {
    }

    public Bag(Bag parent)
    {
      myParent = parent;
    }

    public object Get(string key)
    {
      object o;
      if (myBag.TryGetValue(key, out o))
        return o;

      return myParent == null ? null : myParent.Get(key);
    }

    public void Add(string key, object o)
    {
      myBag[key] = o;
    }
  }
}