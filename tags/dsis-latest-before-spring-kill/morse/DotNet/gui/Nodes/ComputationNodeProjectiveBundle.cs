using System;
using System.Windows.Forms;
using System.Collections;
using MorseKernelATL;

namespace gui
{
	/// <summary>
	/// Summary description for ComputationNodeProjectiveBundle.
	/// </summary>
	public class ComputationNodeProjectiveBundle : ComputationNode 
	{
		private CProjectiveBundleGraph bundle;
		private IGraphInfo info;
		private InfoGraphParser gps;


		public CProjectiveBundleGraph kernelNode 
		{
			get 
			{
				return bundle;
			}
		}


		public ComputationNodeProjectiveBundle(CProjectiveBundleGraph bundle) 
		{
			this.bundle = bundle;
			this.info = bundle.graphInfo();
			this.gps = new InfoGraphParser(this.info);
			this.Text = string.Format("Extended Symbolic Image. Nodes: {0}, Edges: {1}", info.nodes(), info.edges());	

			bundle.newChildMorseSpectrum += new IProjectiveBundleEvents_newChildMorseSpectrumEventHandler(bundle_newChildMorseSpectrum);
			bundle.newChildProjectiveBundle += new IProjectiveBundleEvents_newChildProjectiveBundleEventHandler(bundle_newChildProjectiveBundle);
			
		}

		public void subdevide() 
		{	
			(bundle as ISubdevidable).Subdevide(ComputationParametersFactory.Params(null, bundle as IGraph));
			
			//bundle.
		}

		public void subdevidePoint()
		{
			//
		}

		public void morseSpectrun() 
		{
			if (info.edges() == 0) 
			{
				MessageBox.Show("Unable to estimate Morse Spectrum on graph without any edges. \n Please "
								+ "perform atleat one Subdivision operation ");
			} 
			else 
			{
				//bundle.Morse();
			}
		}

		protected override ComputationNodeMenuItem[] getMenuItems()
		{
			return null;
		}


		public override IEnumerator getActions() 
		{
			ArrayList al = new ArrayList(4);
			al.Add(new NextAction(this));
			al.Add(new PointSIAction(this));
			al.Add(new MorseAction(this));
			return merge(al.GetEnumerator(), base.getActions());
		}

		private void bundle_newChildMorseSpectrum(CMorseSpectrum ms)
		{
			Nodes.Add(new ComputationNodeMorseSpectrum(ms));
			Expand();
		}

		private void bundle_newChildProjectiveBundle(IProjectiveBundle pb)
		{
			Nodes.Add(new ComputationNodeProjectiveBundle((CProjectiveBundleGraph)pb));
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
			private ComputationNodeProjectiveBundle parent;

			public NextAction(ComputationNodeProjectiveBundle parent) : base() 
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

		private class MorseAction : ComputationNodeAction 
		{
			private ComputationNodeProjectiveBundle parent;

			public MorseAction(ComputationNodeProjectiveBundle parent) : base() 
			{
				this.parent = parent;
				this.Text = "Estimate Morse Spectrum";
				this.Click += new EventHandler(NextAction_Click);
			}

			private void NextAction_Click(object sender, EventArgs e)
			{
				parent.morseSpectrun();
			}
		}

		private class PointSIAction : ComputationNodeAction
		{
			private ComputationNodeProjectiveBundle parent;

			public PointSIAction(ComputationNodeProjectiveBundle parent) : base()
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
