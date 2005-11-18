using System;

namespace EugenePetrenko.Gui2.Kernell2.ActionFactory
{
    /// <summary>
    /// Summary description for ActionWrapperAttribute.
    /// </summary>
    /// 
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ActionMappingAttribute : Attribute
    {
        private Type actionInterface;
        private Type parametersInterface;

        public ActionMappingAttribute(Type actionInterface, Type parametersInterface) : base()
        {
            this.actionInterface = actionInterface;
            this.parametersInterface = parametersInterface;
        }

        public Type ActionInterface
        {
            get { return actionInterface; }
        }

        public Type ParametersInterface
        {
            get { return parametersInterface; }
        }
    }
}