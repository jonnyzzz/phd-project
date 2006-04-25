using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Visualization.KernelAction
{
  /// <summary>
  /// Summary description for EmptyResultSet.
  /// </summary>
  public class EmptyResultSet : IResultSet
  {
    public EmptyResultSet()
    {
    }

    public int GetCount()
    {
      return 0;
    }

    public IResultBase GetResult(int index)
    {
      return null;
    }
  }
}