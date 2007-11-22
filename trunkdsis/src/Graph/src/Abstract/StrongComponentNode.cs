using DSIS.Core.Coordinates;

namespace DSIS.Graph.Abstract
{
  public class StrongComponentNode<TCell> : Node<StrongComponentNode<TCell>, TCell> where TCell : ICellCoordinate<TCell>
  {
    private IStrongComponentInfoEx myStrongComponent = null;

    internal StrongComponentNode(TCell coordinate) : base(coordinate)
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