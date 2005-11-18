using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.SIRom
{
    /// <summary>
    /// Summary description for SIRomActionParametersImpl.
    /// </summary>
    public class SIRomActionParametersImpl : ISIRomActionParameters
    {
        private Function function;

        public SIRomActionParametersImpl(Function function)
        {
            this.function = function;
        }

        public IFunction GetFunction()
        {
            return function.IFunction;
        }
    }
}