using System;

namespace guiKernel2.ActionFactory
{
	/// <summary>
	/// Summary description for ActionWrapperAttribute.
	/// </summary>
	/// 
	[AttributeUsage(AttributeTargets.Class)]
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
