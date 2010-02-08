namespace DSIS.Graph.Abstract
{
  public class NodeFlagValue
  {
    private uint myFlags;

    public uint ComponentId
    {
      get { return myFlags & NodeFlags._MASK.Flag; }
    }

    public void SetFlag(NodeFlag mask, bool value)
    {
      if (value)
      {
        myFlags |= mask.Flag;
      }
      else
      {
        myFlags &= ~mask.Flag;
      }
    }

    public bool GetFlag(NodeFlag mask)
    {
      return (myFlags & mask.Flag) == mask.Flag;
    }

    public void SetComponentId(uint componentId)
    {
      myFlags = (componentId & NodeFlags._MASK.Flag) | (myFlags & ~NodeFlags._MASK.Flag);
    }
  }
}