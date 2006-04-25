using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.Projector
{
  /// <summary>
  /// Summary description for ProjectorParametersImpl.
  /// </summary>
  public class ProjectorParametersImpl : IProjectActionParameters
  {
    private int[] devisor;

    public ProjectorParametersImpl(int[] data)
    {
      devisor = data;
    }

    public int GetDevisor(int index)
    {
      return devisor[index];
    }
  }
}