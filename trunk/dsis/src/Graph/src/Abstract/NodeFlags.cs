using System;
using System.Collections.Generic;

namespace DSIS.Graph.Abstract
{
  public class NodeFlags
  {
    private const uint LOOP_FLAG = 0x01000000;
    private const uint FIRST_FLAG = 0x02000000;
    private const uint VALUE_MASK = 0x00FFFFFF;
    private const uint LAST_FLAG = 0xFF000000;

    public static readonly NodeFlag IS_LOOP = new NodeFlag(LOOP_FLAG, "IsLoop");
    internal static readonly NodeFlag _MASK = new NodeFlag(VALUE_MASK, "Fake _MASK");

    private readonly Dictionary<uint, string> myFlags = new Dictionary<uint, string>();

    private void FillFlags()
    {
      for(var flag = FIRST_FLAG; flag < LAST_FLAG; flag<<=1)
      {
        myFlags[flag] = null;
      }
    }

    public NodeFlag CreateFlag(string name)
    {
      foreach (var flag in new List<KeyValuePair<uint, string>>(myFlags))
      {
        if (flag.Value == null)
        {
          myFlags[flag.Key] = name;
          return new NodeFlag(flag.Key, name);
        }
      }
      throw new ArgumentException("Failed to allocate more flags");
    }

    public void RemoveFlag(NodeFlag flag)
    {
      foreach (KeyValuePair<uint, string> pair in new List<KeyValuePair<uint, string>>(myFlags))
      {
        if (flag.Flag == pair.Key)
        {
          myFlags[flag.Flag] = null;
          return;
        }
      }
      throw new ArgumentException("Failed to remove unknown flag");
    }
  }

  public class NodeFlag
  {
    internal readonly uint Flag;
    private readonly string myName;

    public NodeFlag(uint flag, string name)
    {
      Flag = flag;
      myName = name;
    }

    public string Name
    {
      get { return myName; }
    }

    public override string ToString()
    {
      return "NodeFag: " + myName;
    }
  }
}