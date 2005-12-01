using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Actions.ActionImpl.MS2D.Next
{
    /// <summary>
    /// Summary description for MS2DMethodParametersImpl.
    /// </summary>
    public class MS2DMethodParametersImpl : IMS2DProcessParameters
    {
        private int[] factor;
        private Function function;

        public MS2DMethodParametersImpl(int[] factor, Function function)
        {
            this.factor = factor;
            this.function = function;
        }

        public IFunction GetFunction()
        {
            return function.IFunction;
        }

        public int GetFactor(int index)
        {
            return factor[index];
        }


    }
}