using System;
using System.Windows.Forms;
using EugenePetrenko.Gui2.Kernell2.Node;
using EugenePetrenko.Gui2.MorseKernel2;

namespace EugenePetrenko.Gui2.Kernell2.ActionFactory2
{	

    public interface IActionContext
    {
        object GetItem(string name);
    }

	public interface IActionReference
	{
        IActionPresentation Presentation { get; }
	    bool IsActionAplicable(IActionContext context);
	}


    public interface IActionWrapper
    {
        bool ProduceResult { get; }
        IActionParametersPresentation Presentation;
        void Commit(IActionParametersPresentation pr);        
    }

    public interface IActionParametersPresentation
    {
        Control Design {get; }
        string Title { get; }        

        object SaveState();
        void RestoreState(object o);
    }


    public interface IActionPresentation
    {
        string Name { get; }
        string Caption{ get; }
    }
}
