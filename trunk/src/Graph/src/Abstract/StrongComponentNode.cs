using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class StrongComponentNode<TCell, TValue> : Node<StrongComponentNode<TCell, TValue>, TCell, TValue> where TCell: ICellCoordinate<TCell>
  {
    private IStrongComponentInfoEx myStrongComponent = null;

    internal StrongComponentNode(TCell coordinate, TValue value) : base(coordinate, value)
    {
    }

    internal IStrongComponentInfoEx StrongComponent
    {
      get
      {
        if (myStrongComponent != null)
          return myStrongComponent = myStrongComponent.Reference;
        return null;
      }
      set { myStrongComponent = value; }
    }
  }
}