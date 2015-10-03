namespace DSIS.Scheme.Actions
{
  public struct LoopIndex
  {
    public readonly int Index;
    public readonly int Count;

    public LoopIndex(int index, int count)
    {
      Index = index;
      Count = count;
    }

    public LoopIndex Next()
    {
      return new LoopIndex(Index+1, Count);
    }
  }
}