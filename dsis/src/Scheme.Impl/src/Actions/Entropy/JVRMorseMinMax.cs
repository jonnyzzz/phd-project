using DSIS.Graph.Morse;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public class JVRMorseMinMax<Q>
  {    
    public readonly ComputationResult<Q> Max;
    public readonly ComputationResult<Q> Min;

    public JVRMorseMinMax(ComputationResult<Q> max, ComputationResult<Q> min)
    {
      Max = max;
      Min = min;
    }
  }
}