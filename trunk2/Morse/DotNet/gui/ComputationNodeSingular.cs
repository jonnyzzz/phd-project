using System;
using System.Collections;
using System.Windows.Forms;
using MorseKernelATL;

namespace gui
{
	/// <summary>
	/// Summary description for ComputationNodeSingular.
	/// </summary>
	public class ComputationNodeSingular : ComputationNode
	{
		private IKernelNode node;

		public IKernelNode Node
		{
			get
			{
				return node;
			}
		}

		public ComputationNodeSingular(IKernelNode node) : base()
		{		
			this.node = node;
			ComputationNodeDynamicTest.ComputationNodeDynamicTestResult res = ComputationNodeDynamicTest.parseNode(node);
			this.items = res.items;
			this.actions = res.actions;
			registerEvents(node);
		}

		private ComputationNodeMenuItem[] items = new ComputationNodeMenuItem[]{};
		private ComputationNodeAction[] actions = new ComputationNodeAction[]{};

		protected override ComputationNodeMenuItem[] getMenuItems()
		{
			return items;
		}
		
		#region registrationEvents...

        private void registerEvents(IKernelNode mnode)
        {
            if (mnode is CSymbolicImageGraph)
            {
                CSymbolicImageGraph node = mnode as CSymbolicImageGraph;
                node.noChilds += new AbstractEvent_noChildsEventHandler(noChilds);
                node.newKernelNode += new AbstractEvent_newKernelNodeEventHandler(newNode);
                node.noImplementation += new AbstractEvent_noImplementationEventHandler(noImplementation);				
                node.newComputationResult += new AbstractEvent_newComputationResultEventHandler(newComputationResult);
                generateCaption(node);	
            }
            if (mnode is CSymbolicImageGroup) 
            {
                CSymbolicImageGroup node = mnode as CSymbolicImageGroup;
                node.noChilds += new AbstractEvent_noChildsEventHandler(noChilds);
                node.newKernelNode += new AbstractEvent_newKernelNodeEventHandler(newNode);
                node.noImplementation += new AbstractEvent_noImplementationEventHandler(noImplementation);
                node.newComputationResult += new AbstractEvent_newComputationResultEventHandler(newComputationResult);
                generateCaption(node);				
            }
            if (mnode is CProjectiveBundleGraph)
            {
                CProjectiveBundleGraph node = mnode as CProjectiveBundleGraph;
                node.noChilds += new AbstractEvent_noChildsEventHandler(noChilds);
                node.newKernelNode += new AbstractEvent_newKernelNodeEventHandler(newNode);
                node.noImplementation += new AbstractEvent_noImplementationEventHandler(noImplementation);
                node.newComputationResult += new AbstractEvent_newComputationResultEventHandler(newComputationResult);
                generateCaption(node);
            }
            if (mnode is CProjectiveBundleGroup)
            {
                CProjectiveBundleGroup node = mnode as CProjectiveBundleGroup;
                node.noChilds += new AbstractEvent_noChildsEventHandler(noChilds);
                node.newKernelNode += new AbstractEvent_newKernelNodeEventHandler(newNode);
                node.noImplementation += new AbstractEvent_noImplementationEventHandler(noImplementation);
                node.newComputationResult += new AbstractEvent_newComputationResultEventHandler(newComputationResult);
                generateCaption(node);
            }
            if (mnode is CMorseSpectrum)
            {
                CMorseSpectrum node = mnode as CMorseSpectrum;
                generateCaption(node);				
            }
        }
			
        private void unregisterEvents(IKernelNode mnode)
        {
            if (mnode is CSymbolicImageGraph)
            {
                CSymbolicImageGraph node = mnode as CSymbolicImageGraph;
                node.noChilds -= new AbstractEvent_noChildsEventHandler(noChilds);
                node.newKernelNode -= new AbstractEvent_newKernelNodeEventHandler(newNode);
                node.noImplementation -= new AbstractEvent_noImplementationEventHandler(noImplementation);				
                node.newComputationResult -= new AbstractEvent_newComputationResultEventHandler(newComputationResult);
                generateCaption(node);	
            }
            if (mnode is CSymbolicImageGroup) 
            {
                CSymbolicImageGroup node = mnode as CSymbolicImageGroup;
                node.noChilds -= new AbstractEvent_noChildsEventHandler(noChilds);
                node.newKernelNode -= new AbstractEvent_newKernelNodeEventHandler(newNode);
                node.noImplementation -= new AbstractEvent_noImplementationEventHandler(noImplementation);
                node.newComputationResult -= new AbstractEvent_newComputationResultEventHandler(newComputationResult);
                generateCaption(node);				
            }
            if (mnode is CProjectiveBundleGraph)
            {
                CProjectiveBundleGraph node = mnode as CProjectiveBundleGraph;
                node.noChilds -= new AbstractEvent_noChildsEventHandler(noChilds);
                node.newKernelNode -= new AbstractEvent_newKernelNodeEventHandler(newNode);
                node.noImplementation -= new AbstractEvent_noImplementationEventHandler(noImplementation);
                node.newComputationResult -= new AbstractEvent_newComputationResultEventHandler(newComputationResult);
                generateCaption(node);
            }
            if (mnode is CProjectiveBundleGroup)
            {
                CProjectiveBundleGroup node = mnode as CProjectiveBundleGroup;
                node.noChilds -= new AbstractEvent_noChildsEventHandler(noChilds);
                node.newKernelNode -= new AbstractEvent_newKernelNodeEventHandler(newNode);
                node.noImplementation -= new AbstractEvent_noImplementationEventHandler(noImplementation);
                node.newComputationResult -= new AbstractEvent_newComputationResultEventHandler(newComputationResult);
                generateCaption(node);
            }
            if (mnode is CMorseSpectrum)
            {
                CMorseSpectrum node = mnode as CMorseSpectrum;
                generateCaption(node);				
            }
        }
	
		#endregion

		#region event hanlers...
		private void noChilds()
		{
			MessageBox.Show("No strongs components were found.", "Computation results");
		}

		private void noImplementation() {
			MessageBox.Show("No implementation for that action. Sorry,", "Computation results");
		}

		private void newNode(IKernelNode node)
		{
            Nodes.Add(ComputationNode.createComputationNode(node));
			Expand();
		}

		private void newComputationResult(IComputationResult result)
		{
			registerComputationEvents(result);
			GraphOperationSelector go = new GraphOperationSelector();
			if (go.ShowModal(null, this, result) == DialogResult.OK)
			{
				go.DoSelected();
			}
		}

		private void registerComputationEvents(IComputationResult aresult)
		{
			if (aresult is CComputationGraphResult)
			{
				CComputationGraphResult result = aresult as CComputationGraphResult;				
				result.noChilds += new AbstractComputationEvent_noChildsEventHandler(noChilds);
				result.noImplementation += new AbstractComputationEvent_noImplementationEventHandler(noImplementation);
			}
		}
		#endregion
	
		#region generate Caption methods
		private void generateCaption(CSymbolicImageGraph node)
		{
			InfoGraphParser parser = new InfoGraphParser(node.graphInfo());
            
			Text = string.Format("Symbolic Image. Nodes : {0}", parser.Nodes);			
		}

		private void generateCaption(CSymbolicImageGroup node)
		{
			InfoGraphParser parser = new InfoGraphParser(node.graphInfo());
            
			Text = string.Format("Symbolic Image. Group. Nodes : {0}", parser.Nodes);						
		}

		private void generateCaption(CProjectiveBundleGraph node)
		{
			InfoGraphParser parser = new InfoGraphParser(node.graphInfo());
            
			Text = string.Format("Projective Bundle. Nodes : {0}, Edges : {1}", parser.Nodes, parser.Edges);
		}

		private void generateCaption(CProjectiveBundleGroup node)
		{
			InfoGraphParser parser = new InfoGraphParser(node.graphInfo());
            
			Text = string.Format("Projective Bundle. Group. Nodes : {0}, Edges : {1}", parser.Nodes, parser.Edges);
		}

		private void generateCaption(CMorseSpectrum node)
		{
			Text = string.Format("Morse Spectrum estimation: [{0}; {1}]", node.lowerBound, node.upperBound);
		}
		
		#endregion
	}
}
