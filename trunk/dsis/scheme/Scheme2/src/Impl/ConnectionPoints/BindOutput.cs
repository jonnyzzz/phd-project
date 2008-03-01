using DSIS.Scheme2.XmlModel;

namespace DSIS.Scheme2.Impl.ConnectionPoints
{
  public class BindOutput<T> : IOutputConnectionPointWith
  {
    private readonly IInputConnectionPoint<T> myPoint;

    public BindOutput(IInputConnectionPoint<T> point)
    {
      myPoint = point;
    }

    public void Register<Q>(IOutputConnectionPoint<Q> point)
    {
      Bind.BindPoints(myPoint, point);
    }
  }
}