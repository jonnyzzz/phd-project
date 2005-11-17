using System;

namespace guiControls.Grid.Rows
{
	/// <summary>
	/// Summary description for ExGrigRowChangedHandler.
	/// </summary>
	/// 
    
    public delegate bool NeedSaveRowChange();

	public class ExGridRowChangedHandler : IExGridRow, IExGridHandler
	{
        private NeedSaveRowChange exDeleg;
        private IExGridRow exGrid;

	    public ExGridRowChangedHandler(NeedSaveRowChange exDeleg, IExGridRow exGrid)
	    {
	        this.exDeleg = exDeleg;
	        this.exGrid = exGrid;
	    }

	    public string this[int index]
	    {
	        get { return exGrid[index]; }
	        set { exGrid[index] = value; }
	    }

	    public string Caption
	    {
	        get { return exGrid.Caption; }
	    }

	    public bool NeedAcceptRowChanged()
	    {
	        return exDeleg();
	    }
	}
}
