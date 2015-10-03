namespace DSIS.Scheme2.ConnectionPoints
{
  /// <summary>
  /// Object produces data
  /// </summary>
  public interface IOutputConnectionPoint : IConnectionPoint
  {
    void With(IOutputConnectionPointWith with);
    void Bind(IInputConnectionPoint pt);
  }

  public delegate void DataReady<T>(T data);

  public interface IOutputConnectionPoint<T> : IOutputConnectionPoint
  {
    event DataReady<T> OnDataReady;
  }

  public interface IOutputConnectionPointWith
  {
    void Register<T>(IOutputConnectionPoint<T> point);
  }
}