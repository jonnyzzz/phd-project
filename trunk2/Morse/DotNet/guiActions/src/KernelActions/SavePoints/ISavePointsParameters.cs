using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.KernelActions.SavePoints
{
    /// <summary>
    /// Summary description for ISavePointsParameters.
    /// </summary>
    public interface ISavePointsParameters : IParameters
    {
        string FilePath { get; }
    }
}