using System;
using MorseKernel2;

namespace guiKernel2.ActionFactory
{
	/// <summary>
	/// Summary description for IDisabledAction.
	/// </summary>
	public interface IDisabledAction // : IAction
	{		
        void SetComment(string comment);

        string Comment{ get; }
        string Caption{ get; }
	}

    public interface IDisabledActionInterface : IAction
    {
        
    }
}
