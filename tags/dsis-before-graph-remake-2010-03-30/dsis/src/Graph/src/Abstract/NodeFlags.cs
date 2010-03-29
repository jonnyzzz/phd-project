using System;
using System.Collections.Generic;
using System.Linq;

namespace DSIS.Graph.Abstract
{
  public class NodeFlags
  {
    private const uint FIRST_FLAG = 0x01000000;
    private const uint VALUE_MASK = 0x00FFFFFF;
    private const uint LAST_FLAG = 0xFF000000;
    
    internal static readonly NodeFlag _MASK = new NodeFlag(VALUE_MASK, "Fake _MASK", null, false);

    private readonly Dictionary<uint, string> myFlags = new Dictionary<uint, string>();
    private readonly HashSet<uint> myUsedFlags = new HashSet<uint>();

    public NodeFlags()
    {
      FillFlags();
    }

    private void FillFlags()
    {
      for(var flag = FIRST_FLAG; flag > 0 && flag < LAST_FLAG; flag<<=1)
      {
        myFlags[flag] = null;
      }
    }

    public NodeFlag CreateFlag(string name)
    {
      var list = new List<KeyValuePair<uint, string>>(myFlags.Where(x=>x.Value == null));
      list.Sort((x,y)=>(myUsedFlags.Contains(x.Key) ? 1 : -1).CompareTo(myUsedFlags.Contains(y.Key) ? 1 : -1));
      foreach (var flag in list)
      {
        if (flag.Value == null)
        {
          myFlags[flag.Key] = name;
          var reuse = myUsedFlags.Contains(flag.Key);
          myUsedFlags.Add(flag.Key);
          return new NodeFlag(flag.Key, name, this, reuse);
        }
      }
      throw new ArgumentException("Failed to allocate more flags");
    }

    public void RemoveFlag(NodeFlag flag)
    {
      if (!ReferenceEquals(flag.Holder, this))
      {
        throw new ArgumentException("Flag object was not created by that instance of NodeFlags");
      }

      if (myFlags.Any(pair => flag.Flag == pair.Key))
      {
        myFlags[flag.Flag] = null;
        return;
      }
      throw new ArgumentException("Failed to remove unknown flag");
    }
  }
}