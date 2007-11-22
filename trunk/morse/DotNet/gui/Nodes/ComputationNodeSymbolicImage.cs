using System;
using System.Windows.Forms;
using System.Collections;
using MorseKernelATL;

namespace gui
{
	/// <summary>
	/// Summary description for ComputationNodeSymbolicImage.
	/// </summary>
	public class ComputationNodeSymbolicImage : ComputationNode 
	{
		private CSymbolicImageGraph node;
		private IGraphInfo info;
		private InfoGraphParser gps;

		public CSymbolicImageGraph kernelNode 
		{
			get 
			{
				return node;
			}
		}


		public ComputationNodeSymbolicImage(CSymbolicImageGraph node)
		{
			this.node = node;
			this.info = node.graphInfo();
			this.gps = new InfoGraphParser(this.info);

			this.Text = string.Format("Symbolic Image. Nodes: {0}", info.nodes());	
			
			node.newChildProjectiveBundle += new ISymbolicImageEvents_newChildProjectiveBundleEventHandler(node_newChildProjectiveBundle);
			node.newChildSymbolicImage += new ISymbolicImageEvents_newChildSymbolicImageEventHandler(node_newChildSymbolicImage);
			
		}

		public override IEnumerator getActions() 
		{			
			ArrayList al = new ArrayList(3);
			al.Add(new NextAction(this));
			al.Add(new PointSIAction(this));
			al.Add(new MSAction(this));
			return merge(al.GetEnumerator(), base.getActions());
		}

		public void subdevide() 
		{
			//node.subdevision();			
		}

		public void subdevidePoint()
		{
			int[] i = new int[] { 5,5,5,5,5,5,5,5,5,5};
			//node.subdevidePointMethod(i.Length, ref i[0]);
		}

		public void projectiveBundle() 
		{
			//node.projectiveBundle();
		}

		private void node_newChildProjectiveBundle(IProjectiveBundle bundle)
		{
			Nodes.Add(new ComputationNodeProjectiveBundle((CProjectiveBundleGraph) bundle));
			Expand();
		}

		private void node_newChildSymbolicImage(ISymbolicImage image)
		{
			Nodes.Add (new ComputationNodeSymbolicImage((CSymbolicImageGraph)image));
			Expand(); 				
		}

		public override string getInfoEdges()
		{
			return string.Format("{0}", info.edges());
		}

		public override string getInfoGridNumber()
		{
			return gps.GridNum();
		}

		public override string getInfoGridSize()
		{
			return gps.GridSize();
		}

		public override string getInfoNodes()
		{
			return string.Format("{0}", info.nodes());
		}

		public override string getInfoSpace()
		{
			return gps.Space();
		}

		private class NextAction : ComputationNodeAction 
		{		
			private ComputationNodeSymbolicImage parent;

			public NextAction(ComputationNodeSymbolicImage parent) : base()
			{
				this.parent = parent;
				this.Text = "Subdevide";
				this.Click += new EventHandler(NextAction_Click);
			}

			private void NextAction_Click(object sender, EventArgs e)
			{
				parent.subdevide();
			}
		}

		private class MSAction : ComputationNodeAction 
		{		
			private ComputationNodeSymbolicImage parent;

			public MSAction(ComputationNodeSymbolicImage parent) : base()
			{
				this.parent = parent;
				this.Text = "Projective Bundle";
				this.Click += new EventHandler(NextAction_Click);
			}

			private void NextAction_Click(object sender, EventArgs e)
			{
				parent.projectiveBundle();
			}
		}

		private class PointSIAction : ComputationNodeAction
		{
			private ComputationNodeSymbolicImage parent;

			public PointSIAction(ComputationNodeSymbolicImage parent) : base()
			{
				this.parent = parent;
				this.Text = "subdevide point method";

				this.Click += new EventHandler(PointSIAction_Click);
			}

			private void PointSIAction_Click(object sender, EventArgs e)
			{
				parent.subdevidePoint();				
			}
		}
	}
}
