namespace EugenePetrenko.Core.FormGenerator.ListSelector
{
  public interface IListInfo<Q>
  {
    string Description { get; }

    string Title { get; }

    bool Enabled { get;  }

    Q Value { get; }
  }
}