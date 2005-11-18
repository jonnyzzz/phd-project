using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl
{
    /// <summary>
    /// Summary description for ComputationParametersImpl.
    /// </summary>
    public class ComputationParametersImpl : IComputationParameters
    {
        private Function function;

        public ComputationParametersImpl(Function function)
        {
            this.function = function;
        }

        public IFunction GetFunction()
        {
            return function.IFunction;
        }
    }
}