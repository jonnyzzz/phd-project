using System.Collections.Generic;
using DSIS.Core.Coordinates;

namespace DSIS.Graph.Morse
{
  public class MorseStrongComponentGraph<T> : IMorseEvaluatorGraph<T> where T : ICellCoordinate
  {
    private readonly IStrongComponentInfo[] myComponentInfos;
    private readonly IGraphStrongComponents<T> myComponents;

    public MorseStrongComponentGraph(IGraphStrongComponents<T> components, IStrongComponentInfo componentInfos)
    {
      myComponentInfos = new[] {componentInfos};
      myComponents = components;
    }

    public IEnumerable<INode<T>> GetNodes(INode<T> node)
    {
      return myComponents.GetEdgesWithFilteredEdges(node, myComponentInfos);
    }

    public IEnumerable<INode<T>> GetNodes()
    {
      return myComponents.GetNodes(myComponentInfos);
    }
  }
}