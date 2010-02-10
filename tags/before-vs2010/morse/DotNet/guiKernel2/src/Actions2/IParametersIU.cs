using System;
using System.Windows.Forms;

namespace EugenePetrenko.Gui2.Kernell2.Actions2
{
	/// <summary>
	/// Summary description for IParametersIU.
	/// </summary>
	public interface IParametersIU
	{
        string FormTitle { get; }
	    Control ParametersInput { get; }
        bool ShowControl { get; }

		object SaveData();
        void LoadData(object o);
	}
}
