using System;
using System.Windows.Forms;
using gui.Logger;
using gui.Tree.Node.Forms;
using MorseKernelATL;

namespace gui.Tree.Node.Factory
{
	/// <summary>
	/// Summary description for ComputationParametersFactory.
	/// </summary>
	public class ComputationParametersFactory
	{
		protected ComputationParametersFactory()
		{
		}

		#region dynamic casters
		private static int[][] toArrays(ISubdevideParams subd, int dimension)
		{
			int[][] data = new int[1][];
			data[0] = new int[dimension];
			if (subd != null )
			{
				for (int i=0; i<dimension; i++)
				{
					data[0][i] = subd.getCellDevider(i);				
				}
			} else
			{
				for (int i=0; i<dimension; i++)
				{
					data[0][i] = 2;
				}
			}
			return data;
		}

		private static int[][] toArrays(ISubdevidePointParams subd, int dimension)
		{
			int[][] data = new int[2][];
			data[0] = new int[dimension];
			data[1] = new int[dimension];
			if (subd != null)
			{							
				for (int i=0; i<dimension; i++)
				{
					data[0][i] = subd.getCellDevider(i);
					data[1][i] = subd.getCellPoints(i);
				}
			} else
			{
				for (int i=0; i<dimension; i++)
				{
					data[0][i] = 2;
					data[1][i] = 2;
				}				
			}
			return data;			
		}

		private static int[][] toArrays(IExtendablePointParams subd, int dimension)
		{
			return toArrays(subd as ISubdevideParams, dimension);
		}
		#endregion

		#region ISubdevideParams...
		public static ISubdevideParams ParamsSubdevide(IWin32Window owner, IGraph node, ISubdevideParams param)
		{
		    Log.LogMessage(typeof(ISubdevideParams), "ISubdevideParams invoke");

			NextStepParams ps = new NextStepParams();
			int dimension = node.graphDimension();
			int[][] par = toArrays(param, dimension);
            	
			if (ps.ShowDialog(owner, par, dimension) != DialogResult.OK) 
			{
				return null;
			} 
			else 
			{
				par = ps.Result;
				return new SubdevideParams(par[0]);			
			}
		}

		protected class SubdevideParams : ISubdevideParams
		{	
			private int[] devider;		

			public SubdevideParams(int[] devider)
			{
				this.devider = devider;
			}
			public int getCellDevider(int axis)
			{
				if (axis < devider.Length)
				{
					return devider[axis];
				} else
				{
					throw new NotImplementedException();
				}
			}

			public void updateProgressBar(int minValue, int maxValue, int currentValue)
			{
				Runner.ComputationForm.updateProgressBar(minValue, maxValue, currentValue);
			}

		}
		#endregion


		#region ISubdevidablePointParams...
		public static ISubdevidePointParams ParamsSubdevidePoint(IWin32Window owner, IGraph node, ISubdevidePointParams param)
		{
			NextStepParams ps = new NextStepParams();
			int dimension = node.graphDimension();
			int[][] par = toArrays(param, dimension);
            	
			if (ps.ShowDialog(owner, par, dimension) != DialogResult.OK)
			{
				return null;
			} 
			else 
			{
				par = ps.Result;
				return new SubdevididePointParams(par[0], par[1]);		
			}
		}

		protected class SubdevididePointParams : ISubdevidePointParams
		{
			private SubdevideParams factor;
			private SubdevideParams ks;
			public SubdevididePointParams(int[] factor, int[] ks)
			{
				this.factor = new SubdevideParams(factor);
				this.ks = new SubdevideParams(ks);
			}
			public int getCellDevider(int axis)
			{
				return factor.getCellDevider(axis);
			}

			public void updateProgressBar(int minValue, int maxValue, int currentValue)
			{
				Runner.ComputationForm.updateProgressBar(minValue, maxValue, currentValue);
			}

			public int getCellPoints(int axis)
			{
				return ks.getCellDevider(axis);
			}
		}
		#endregion


		#region IExtendibleParams...
        /*
		public static IExtendableParams ParamsExtend(IWin32Window owner, IExtendable node, IExtendableParams param)
		{
			NextStepParams ps = new NextStepParams();
			int dimension = node.NewDimension();
			int[][] par = toArrays(param, dimension);
            	
			if (ps.ShowDialog(owner, par, dimension) != DialogResult.OK)
			{
				return null;
			} 
			else 
			{	
				par = ps.Result;
				return new ExtendableParams(par[0]);		
			}
		}

		protected class ExtendableParams : SubdevideParams, IExtendableParams
		{
			public ExtendableParams(int[] factor) : base(factor) {}
		}
        */
		#endregion


        
        public static IExtendablePointParams ParamsExtend(IWin32Window owner, IComputationExtendingResult result, IExtendablePointParams param)
        {
            NextStepParams ps = new NextStepParams();
            int dimension = result.PointMethodProjectiveExtensionDimension();
            int[][] par = toArrays(param, dimension);
            	
            if (ps.ShowDialog(owner, par, dimension) != DialogResult.OK)
            {
                return null;
            } 
            else 
            {	
                par = ps.Result;
                return new ExtendableParams(par[0]);		
            }
        }

        protected class ExtendableParams : SubdevideParams, IExtendablePointParams
        {
            public ExtendableParams(int[] factor) : base(factor) {}
        }

	}
}
