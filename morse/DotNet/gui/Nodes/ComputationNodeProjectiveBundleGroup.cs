using System;
using System.Drawing;
using MorseKernelATL;
using System.Collections;
using System.Windows.Forms;

namespace gui
{
	/// <summary>
	/// Summary description for ComputationNodeProjectiveBundleGroup.
	/// </summary>
	public class ComputationNodeProjectiveBundleGroup : ComputationNodeGroup
	{

		private CProjectiveBundleGroup group;

		public ComputationNodeProjectiveBundleGroup() : base(typeof(ComputationNodeProjectiveBundle))
		{
			
		}

		public override IEnumerator getActions()
		{
			ArrayList al = new ArrayList(3);
			al.Add(new NextAction(this));
			al.Add(new PointSIAction(this));
			al.Add(new MorseAction(this));
			return merge(al.GetEnumerator(), base.getActions ());
		}


		private void createClass() 
		{
			group = new CProjectiveBundleGroupClass();

			Console.WriteLine("number of nodes = {0}", nodes.Count);

			IEnumerator ie = nodes.GetEnumerator();
			for (ie.Reset(); ie.MoveNext(); ) 
			{	
				group.addNode((ie.Current as ComputationNodeProjectiveBundle).kernelNode);
			}
			info = group.graphInfo();
			gps = new InfoGraphParser(info);
			
			group.newChildMorseSpectrum += new IProjectiveBundleEvents_newChildMorseSpectrumEventHandler(bundle_newChildMorseSpectrum);
			group.newChildProjectiveBundle += new IProjectiveBundleEvents_newChildProjectiveBundleEventHandler(bundle_newChildProjectiveBundle);

		}

		public void subdevide() 
		{	
			//createClass();
			//group.subdevision();
		}

		public void subdevidePoint() 
		{	
			//createClass();
			//group.subdevisionPoint(5, ref (new int[]{5,5,5,5,5,5,5,5})[0]);
		}


		private void morseSpectrum() 
		{
			createClass();
			if (info.edges() == 0) 
			{
				MessageBox.Show("Unable to estimate Morse Spectrum on graph without any edges. \n Please "
					+ "perform atleat one Subdivision operation ");
			} 
			else 
			{
				//group.morseSpectrum();
			}
		}

		private void bundle_newChildMorseSpectrum(CMorseSpectrum ms)
		{
			addThisNode();
			Nodes.Add(new ComputationNodeMorseSpectrum(ms));
			Expand();
		}

		private void bundle_newChildProjectiveBundle(IProjectiveBundle pb)
		{
			addThisNode();
			Nodes.Add(new ComputationNodeProjectiveBundle((CProjectiveBundleGraph)pb));
			Expand();
		}

		
		public override string getInfoName()
		{
			if (gps != null && info != null) 
			{
				return string.Format("Group : Extended Symbolic Image. Nodes: {0}. Edges: {1}", info.nodes(), info.edges());
			} 
			else 
			{
				return null;
			}
		}


		private class NextAction : ComputationNodeAction 
		{
			private ComputationNodeProjectiveBundleGroup parent;

			public NextAction(ComputationNodeProjectiveBundleGroup parent) : base() 
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

		private class MorseAction : ComputationNodeAction 
		{
			private ComputationNodeProjectiveBundleGroup parent;

			public MorseAction(ComputationNodeProjectiveBundleGroup parent) : base() 
			{
				this.parent = parent;
				this.Text = "Group: Estimate Morse Spectrum";
				this.Click += new EventHandler(NextAction_Click);
			}

			private void NextAction_Click(object sender, EventArgs e)
			{
				parent.morseSpectrum();
			}
		}

		private class PointSIAction : ComputationNodeAction
		{
			private ComputationNodeProjectiveBundleGroup parent;

			public PointSIAction(ComputationNodeProjectiveBundleGroup parent) : base()
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