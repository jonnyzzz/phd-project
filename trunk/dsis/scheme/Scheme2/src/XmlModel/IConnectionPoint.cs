using System.Collections.Generic;

namespace DSIS.Scheme2.XmlModel
{  
  public interface IConnectionPoint
  {
    string Name { get; }
  }

  /// <summary>
  /// Object produces data
  /// </summary>
  public interface IOutputConnectionPoint : IConnectionPoint {
    void With(IOutputConnectionPointWith with);
    void Bind(IInputConnectionPoint pt);
  }

  public delegate void DataReady<T>(T data);

  public interface IOutputConnectionPoint<T> : IOutputConnectionPoint {
    event DataReady<T> OnDataReady;    
  }
    
  public interface IOutputConnectionPointWith
  {
    void Register<T>(IOutputConnectionPoint<T> point);
  }
  
  /// <summary>
  /// Object reads data
  /// </summary>
  public interface IInputConnectionPoint : IConnectionPoint {
    void With(IInputConnectionPointWith with);
    void Bind(IOutputConnectionPoint pt);
  }
  
  public interface IInputConnectionPoint<T> : IInputConnectionPoint {
    void DataReady(T obj);    
  }
    
  public interface IInputConnectionPointWith
  {
    void Register<T>(IInputConnectionPoint<T> point);
  }

  public interface INode
  {
    ICollection<IInputConnectionPoint> Input { get; }
    ICollection<IOutputConnectionPoint> Output { get; }

    string Name { get; }
  }
}