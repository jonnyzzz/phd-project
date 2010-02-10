using System;
using System.Collections;

namespace EugenePetrenko.MorseGraphGenerator
{
	/// <summary>
	/// Summary description for Node.
	/// </summary>
	public class Node
	{
		private static int counter = 0;
		public static Node Create(double value)
		{
			return new Node(counter++, value);
		}

		private int id;
		private double value;
		public Node(int id, double value)
		{
			this.id = id;
			this.value = value;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Node)) return false;
			return id == ((Node)obj).id;
		}

		public override int GetHashCode()
		{
			return id;
		}

		public double Value
		{
			get { return value; }
		}
	}
}
