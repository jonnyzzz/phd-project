using System;
using System.Collections;

namespace EugenePetrenko.MorseGraphGenerator
{
	/// <summary>
	/// Summary description for Generator.
	/// </summary>
	public class Generator
	{

		/// <summary>
		/// Assume graph have only one strong components
		/// We don't need to store node info, because all 
		/// edges belongs to some (1 or more) loops of that graph
		/// </summary>

		private ArrayList loops = new ArrayList();  //Loop

		public Generator()
		{
			Init();			
		}

		private void Init()
		{
			Node node1 = Node.Create(1);
			Node node2 = Node.Create(1);

			loops.Add(new Loop(node1, node2, node1));			
		}


		private Loop extremaLoop = null;
        
		public Loop ExtramaLoop
		{
			get
			{
				if (extremaLoop == null)
					FindExtremaLoop();
				return extremaLoop;		
			}
		}

		private void FindExtremaLoop()
		{
			foreach (Loop loop in loops)
			{
				if (extremaLoop != null && extremaLoop.Value < loop.Value)
					extremaLoop = loop;
			}
		}


	}
}
