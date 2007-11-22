using System;
using System.Collections;

namespace EugenePetrenko.MorseGraphGenerator
{
	/// <summary>
	/// Summary description for Loop.
	/// </summary>
	public class Loop
	{
		private readonly ArrayList nodes = new ArrayList();

		public Loop(params Node[] nodes)
		{
			this.nodes.AddRange(nodes);
		}

		public Node[] Nodes
		{
			get { return (Node[])nodes.ToArray(typeof(Node)); }
		}

		public bool Contains(Node node)
		{
			return nodes.Contains(node);
		}

		public double Value
		{
			get
			{
				double value = 0;
				foreach (Node node in nodes)
				{
					value += node.Value;
				}
				value /= nodes.Count;

				return value;
			}
		}

		public static Loop[] Add(Loop loop1, Loop loop2)
		{
			foreach (Node node in loop1.Nodes)
			{
				
			}
		}
	}
}
