using System;
using System.Collections;

namespace guiTest.Util
{
	/// <summary>
	/// Summary description for Util.
	/// </summary>
	public class Util
	{
		public static guiKernel2.Document.Function CreateFunction(double[] left, double[] right, int[] grid, string[] equations)
		{
			ArrayList strings = new ArrayList();
			for (int i=0; i<left.Length; i++)
			{
				strings.Add( string.Format("space_min{0}={1};space_max{0}={2};y{0}={3};grid{0}={4}", i + 1, left[i], right[i], equations[i], grid[i]));
			}
			strings.Add("iterations=0;_dimension=" + left.Length + ";");
			return new guiKernel2.Document.Function((string[])strings.ToArray(typeof(string)));
		}
	}
}
