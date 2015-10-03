namespace DSIS.UI.FunctionDialog.UI
{
  public interface IListInfo<Q>
  {
    string Description { get; }

    string Title { get; }

    bool Enabled { get;  }

    Q Value { get; }
  }
}