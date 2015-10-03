using System;
using MorseKernelATL;
using System.Collections;
using System.Windows.Forms;

namespace gui
{
	/// <summary>
	/// Summary description for ComputationNodeSymbolicImageGroup.
	/// </summary>
	public class ComputationNodeSymbolicImageGroup : ComputationNodeGroup
	{
		private CSymbolicImageGroup group;

		public ComputationNodeSymbolicImageGroup() : base (typeof(ComputationNodeSymbolicImage))
		{			
		
		}


		public override IEnumerator getActions()
		{
			ArrayList al = new ArrayList(4);
			al.Add(new NextAction(this));
			al.Add(new PointSIAction(this));
			al.Add(new MSAction(this));
			return merge(al.GetEnumerator(), base.getActions ());
		}


		private void createClass() 
		{
			group = new CSymbolicImageGroupClass();

			Console.WriteLine("number of nodes = {0}", nodes.Count);

			IEnumerator ie = nodes.GetEnumerator();
			for (ie.Reset(); ie.MoveNext(); ) 
			{	
				group.addNode((ie.Current as ComputationNodeSymbolicImage).kernelNode);
			}
			info = group.graphInfo();
			gps = new InfoGraphParser(info);

			group.newChildProjectiveBundle += new ISymbolicImageEvents_newChildProjectiveBundleEventHandler(node_newChildProjectiveBundle);
			group.newChildSymbolicImage += new ISymbolicImageEvents_newChildSymbolicImageEventHandler(node_newChildSymbolicImage);			
		}
		
		private void node_newChildProjectiveBundle(IProjectiveBundle bundle)
		{
			addThisNode();
			Nodes.Add(new ComputationNodeProjectiveBundle((CProjectiveBundleGraph) bundle));
			Expand();
		}

		private void node_newChildSymbolicImage(ISymbolicImage image)
		{
			addThisNode();
			Nodes.Add (new ComputationNodeSymbolicImage((CSymbolicImageGraph)image));
			Expand(); 				
		}


		private void subdevide() 
		{
			//createClass();							
			//group.subdevision();
		}

		private void projectiveBundle() 
		{
			//createClass();
			//group.projectiveBundle();
		}

		private void subdevidePoint() 
		{
			//createClass();							
			//group.subdevidePointMethod(5, ref (new int[]{5,5,5,5,5,5,5,5})[0]);
		}




		public override string getInfoName()
		{
			if (gps != null && info != null) 
			{
				return string.Format("Group : Symbolic Image. Nodes: {0}", info.nodes());
			} 
			else 
			{
				return null;
			}
		}





		private class NextAction : ComputationNodeAction 
		{		
			private ComputationNodeSymbolicImageGroup parent;

			public NextAction(ComputationNodeSymbolicImageGroup parent) : base()
			{
				this.parent = parent;
				this.Text = "Group: Subdevide";
				this.Click += new EventHandler(NextAction_Click);
			}

			private void NextAction_Click(object sender, EventArgs e)
			{
				parent.subdevide();
			}
		}

		private class MSAction : ComputationNodeAction 
		{		
			private ComputationNodeSymbolicImageGroup parent;

			public MSAction(ComputationNodeSymbolicImageGroup parent) : base()
			{
				this.parent = parent;
				this.Text = "Group: Projective Bundle";
				this.Click += new EventHandler(NextAction_Click);
			}

			private void NextAction_Click(object sender, EventArgs e)
			{
				parent.projectiveBundle();
			}
		}

		private class PointSIAction : ComputationNodeAction
		{
			private ComputationNodeSymbolicImageGroup parent;

			public PointSIAction(ComputationNodeSymbolicImageGroup parent) : base()
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
