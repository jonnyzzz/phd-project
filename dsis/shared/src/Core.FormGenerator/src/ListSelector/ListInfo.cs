using EugenePetrenko.Core.FormGenerator.ListSelector;

namespace EugenePetrenko.Core.FormGenerator.ListSelector
{
  public static class ListInfo
  {
    public static ListInfo<Q> Create<Q>(string title, string description, bool enabled, Q value)
    {
      return new ListInfo<Q>(new ItemDescr(title, description), value, enabled);
    }

    public static ListInfo<Q> Create<Q>(ItemDescr title, bool enabled, Q value)
    {
      return new ListInfo<Q>(title, value, enabled);
    }
  }
}