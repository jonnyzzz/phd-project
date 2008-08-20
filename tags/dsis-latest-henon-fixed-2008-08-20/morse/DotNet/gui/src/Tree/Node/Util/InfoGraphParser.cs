using MorseKernelATL;

namespace gui.Tree.Node.Util
{
	/// <summary>
	/// Summary description for InfoGraphParser.
	/// </summary>
	public class InfoGraphParser
	{
		private IGraphInfo info;
		private int dim;

		private string gridSize = "";
		private string gridNum = "";
		private string space = "";

		private string doubleToString(double d)
		{
			return d.ToString().Replace(',', '.');
		}


		public InfoGraphParser(IGraphInfo info)
		{
			this.info = info;
			this.dim = info.dimension();

			for (int i = 0; i < dim; i++)
			{
				gridSize += string.Format("g{0} = {1}; ", i, doubleToString(info.gridSize(i)));
				gridNum += string.Format("s{0} = {1}; ", i, doubleToString(info.gridNumber(i)));
				space += string.Format("[ {0}, {1} ]x", doubleToString(info.spaceMin(i)), info.spaceMax(i));
			}
			if (space.Length > 0)
				space = space.Substring(0, space.LastIndexOf('x'));
		}

		public string GridSize()
		{
			return gridSize;
		}

		public string GridNum()
		{
			return gridNum;
		}

		public string Space()
		{
			return space;
		}

		public int Nodes
		{
			get { return info.nodes(); }
		}

		public int Edges
		{
			get { return info.edges(); }
		}
	}
}