using System.Collections.Generic;

namespace DSIS.Utils
{
  public class BitSet
  {
    private readonly List<uint> myBits = new List<uint>();

    public bool IsSet(long bit)
    {
      int elem = FindIndex(bit);
      EnsureChunk(elem);

      return ReadBit(myBits[elem], FindOffet(bit));
    }

    private void EnsureChunk(int elem)
    {
      while (myBits.Count < elem + 1)
        myBits.Add(0);
    }

    public void Set(long bit, bool value)
    {
      int elem = FindIndex(bit);
      EnsureChunk(elem);
      myBits[elem] = SetBit(myBits[elem], FindOffet(bit), value);
    }

    private static int FindOffet(long bit)
    {
      return (int)(bit%32);
    }
    private static int FindIndex(long bit)
    {
      return (int)(bit/32);
    }

    private static uint SetBit(uint data, int bit, bool value)
    {
      var mask = 1 << bit;
      return value ? (uint) (data | mask) : (uint) (data & ~mask);
    }

    private static bool ReadBit(uint data, int bit)
    {
      var mask = 1 << bit;
      return (data & mask) != 0;
    }
  }
}