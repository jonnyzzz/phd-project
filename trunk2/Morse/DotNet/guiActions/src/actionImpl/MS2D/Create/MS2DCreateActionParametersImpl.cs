using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MS2D.Create
{
    /// <summary>
    /// Summary description for MS2DCreateActionParameters.
    /// </summary>
    public class MS2DCreateActionParametersImpl : IMS2DCreationParameters
    {
        private int factor;

        public MS2DCreateActionParametersImpl(int factor)
        {
            this.factor = factor;
        }

        public int GetFactor()
        {
            return factor;
        }
    }
}