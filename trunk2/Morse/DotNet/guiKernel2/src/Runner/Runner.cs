using System;
using System.Reflection;
using MorseKernel2;

namespace guiKernel2.src.Runner
{
	/// <summary>
	/// Summary description for Runner.
	/// </summary>
	public class Runner
	{
		[MTAThread]
		public static void Main(string[] args)
		{
			IGraphInfo res = new CGraphInfoImplClass();
			IActionAllocator allocator = new MorseKernel2.CActionAllocatorClass();


			Assembly a = typeof(IActionAllocator).Assembly;

			foreach (Type type in a.GetTypes())
			{
				Console.Out.WriteLine("type.Name = {0}", type.Name);
			}


		}
	}
}
