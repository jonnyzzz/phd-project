using System.Collections.Generic;
using System.IO;
using DSIS.Utils;

namespace DSIS.Persistance
{
  public class DiskCache<TK,TV>
  {
    private readonly WeakDictionary<TK, TV> myCache = new WeakDictionary<TK, TV>();
    private readonly Dictionary<TK, string> myFileCache = new Dictionary<TK, string>(EqualityComparerFactory<TK>.GetComparer());
    private readonly IPersistance<TV> myPersitance;
    private readonly IPersistanceFactory myFactory;
    private readonly string myRootFolder;
    private int myIndex;

    public DiskCache(IPersistance<TV> persitance, IPersistanceFactory factory, string rootFolder)
    {
      myPersitance = persitance;
      myFactory = factory;
      myRootFolder = rootFolder;
    }

    private string GetNextFileName()
    {
      return Path.Combine(myRootFolder, "DiskCache_" + typeof (TV).Name + "_" + ++myIndex + ".cache");
    }

    public void AddItem(TK key, TV value)
    {
      myCache.Add(key, value);
      using(var bw = myFactory.CreateWriter(myFileCache[key] = GetNextFileName()))
      {
        myPersitance.Save(value, bw);
      }
    }

    public TV GetItem(TK key)
    {
      TV value;
      if (myCache.TryGetValue(key, out value))
        return value;

      using(var br = myFactory.CreateReader(myFileCache[key]))
      {
        value = myPersitance.Load(br);
      }
      myCache.Add(key, value);

      return value;
    }
  }
}