namespace DSIS.Scheme2.ConnectionPoints
{
  public class BindInput<T> : IInputConnectionPointWith
  {
    private readonly IOutputConnectionPoint<T> myPoint;

    public BindInput(IOutputConnectionPoint<T> point)
    {
      myPoint = point;
    }

    public void Register<Q>(IInputConnectionPoint<Q> point)
    {
      Bind.BindPoints(point, myPoint);
    }
  }
}