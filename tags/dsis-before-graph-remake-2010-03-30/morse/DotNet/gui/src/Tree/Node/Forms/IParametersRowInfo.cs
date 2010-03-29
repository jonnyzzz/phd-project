using System;

namespace gui.Tree.Node.Forms
{
	/// <summary>
	/// Summary description for ICaster.
	/// </summary>
	public interface IParametersRowInfo
	{
		bool Submit(string inputed, int index);

		string Name { get; }

		string DefaultValue(int index);

		int Dimension { get; }
	}
}
