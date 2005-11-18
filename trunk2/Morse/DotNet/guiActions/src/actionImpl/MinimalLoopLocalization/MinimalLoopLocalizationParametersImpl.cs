using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MinimalLoopLocalization
{
    /// <summary>
    /// Summary description for MinimalLoopLocalizationParametersImpl.
    /// </summary>
    public class MinimalLoopLocalizationParametersImpl : IMinimalLoopLocalizationParameters
    {
        private double[] coordinates;

        public MinimalLoopLocalizationParametersImpl(double[] coordinates)
        {
            this.coordinates = coordinates;
        }

        public double GetCoordinate(int id)
        {
            return coordinates[id];
        }
    }
}