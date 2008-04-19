namespace DSIS.Scheme2.ConnectionPoints
{
  /// <summary>
  /// Object reads data
  /// </summary>
  public interface IInputConnectionPoint : IConnectionPoint
  {
    void With(IInputConnectionPointWith with);
    void Bind(IOutputConnectionPoint pt);
  }

  public interface IInputConnectionPoint<T> : IInputConnectionPoint
  {
    void DataReady(T obj);
  }

  public interface IInputConnectionPointWith
  {
    void Register<T>(IInputConnectionPoint<T> point);
  }
}