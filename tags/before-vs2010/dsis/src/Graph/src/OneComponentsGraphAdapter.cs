using DSIS.Core.Coordinates;

namespace DSIS.Graph
{
  public class OneComponentsGraphAdapter<T> : GraphStrongComponentsSubset<T>
    where T : ICellCoordinate
  {
    public OneComponentsGraphAdapter(IGraphStrongComponents<T> comps, IStrongComponentInfo component) :
      base(comps, new[]{component})
    {
    }
  }
}