using System;

namespace guiControls.Grid
{
	/// <summary>
	/// Summary description for IExGridRow.
	/// </summary>
	public interface IExGridRow
	{
		string this[int index] {get; set;}
		string Caption{ get; }
	}
}
