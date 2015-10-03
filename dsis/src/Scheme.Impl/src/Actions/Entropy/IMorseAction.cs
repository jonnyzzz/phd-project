using DSIS.Graph.Morse;

namespace DSIS.Scheme.Impl.Actions.Entropy
{
  public interface IMorseAction : IAction
  {
    IMorseOptions Options { get; }
  }
}