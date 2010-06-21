using System.Collections.Generic;
using DSIS.Graph;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class JVRMorseResult<Q>
  {
    private readonly Dictionary<IStrongComponentInfo, JVRMorseMinMax<Q>> myResults;

    public JVRMorseResult(Dictionary<IStrongComponentInfo, JVRMorseMinMax<Q>> results)
    {
      myResults = results;
    }

    public IEnumerable<IStrongComponentInfo> Components { get { return myResults.Keys; } }

    public JVRMorseMinMax<Q> Get(IStrongComponentInfo comp)
    {
      return myResults[comp];
    }
  }
}