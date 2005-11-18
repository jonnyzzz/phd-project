using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MS2D.Next
{
    /// <summary>
    /// Summary description for MS2DMethodParameters.
    /// </summary>
    public class MS2DMethodParameters : ActionParameters
    {
        private Function function;

        public MS2DMethodParameters(Function function)
        {
            this.function = function;
        }

        protected override IParameters LoadParameters(int factor)
        {
            return new MS2DMethodParametersImpl(factor, function);
        }
    }
}