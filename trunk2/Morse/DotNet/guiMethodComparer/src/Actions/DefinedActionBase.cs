using System;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace Eugene.Petrenko.Gui2.MethodComparer.Actions
{
    public abstract class DefinedActionBase : IDefinedAction, IParameters
    {
        private IMethodParameters methodParameters;

        public DefinedActionBase(IMethodParameters methodParameters)
        {
            this.methodParameters = methodParameters;
        }

        public IFunction GetFunction()
        {
            return GlobalParameters.GetSystemFunction().IFunction;
        }

        public abstract string Name { get; }

        public abstract IAction Action { get; }

        public virtual IParameters GetParameters(ResultSet forSet)
        {
            return this;
        }

        public int GetFactor(int index)
        {
            return GlobalParameters.Subdivision(index);
        }

        protected IMethodParameters GlobalParameters
        {
            get { return methodParameters;}
        }

    }
}