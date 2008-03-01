using System.Collections.Generic;

namespace DSIS.Scheme.XmlModel
{
  public interface IConnectionPoint
  {
    string Name { get; }
    void With(IConnectionPointWith with);
  }

  public delegate void DataReady<T>(T data);

  public interface IConnectionPointWith
  {
    void Register<T>(IConnectionPoint<T> point);
  }

  public interface IConnectionPoint<T> : IConnectionPoint
  {
    event DataReady<T> OnDataReady;
    void DataReady(T obj);
  }

  public interface INode
  {
    ICollection<IConnectionPoint> Input { get; }
    ICollection<IConnectionPoint> Output { get; }

    string Name { get; }
  }
}