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

		#region ISubdevideParams...

		public abstract class ParamsImpl : IParams
		{
			public IProgressBarNotification GetProgressBarNotification()
			{
				return Runner.ComputationForm.ProgressBarNotification;
			}
		}

		public static ISubdevideParams ParamsSubdevide(IWin32Window owner, IGraph node, ISubdevideParams param)
		{
			Log.LogMessage(typeof (ISubdevideParams), "ISubdevideParams invoke");
			int dimension = node.graphDimension();

			IntParametersRowInfo factor = new IntParametersRowInfo(dimension, "Cell division");
			ParametersInputForm dialog = new ParametersInputForm(new IParametersRowInfo[] { factor});

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				return new SubdevideParams(factor.Inputed);
			}
			return null;
		}

		protected class SubdevideParams : ParamsImpl, ISubdevideParams
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
				}
				else
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
			int dimension = node.graphDimension();
			IntParametersRowInfo factor = new IntParametersRowInfo(dimension, "Cell division");
			IntParametersRowInfo ks = new IntParametersRowInfo(dimension, "Points in cell");
			PercentParameterRowInfo offset1 = new PercentParameterRowInfo(dimension, "Upper Offset");
			PercentParameterRowInfo offset2 = new PercentParameterRowInfo(dimension, "Lover Offset");

			ParametersInputForm dialog = new ParametersInputForm(new IParametersRowInfo[] {
					  factor, 
					  ks,
					  offset1,
				      offset2
				});
			

			if (dialog.ShowDialog() == DialogResult.OK)
			{				
				return new SubdevididePointParams(factor.Inputed, ks.Inputed, offset1.Inputed, offset2.Inputed);
			}
			return null;
		}

		protected class SubdevididePointParams : ParamsImpl, ISubdevidePointParams
		{
			private SubdevideParams factor;
			private SubdevideParams ks;
			private double[] overlap1;
			private double[] overlap2;

			public SubdevididePointParams(int[] factor, int[] ks, double[] overlap1, double[] overlap2)
			{
				this.factor = new SubdevideParams(factor);
				this.ks = new SubdevideParams(ks);
				this.overlap1 = overlap1;
				this.overlap2 = overlap2;
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

			public double getOverlaping1(int axis)
			{
				return overlap1[axis]/100;
			}

			public double getOverlaping2(int axis)
			{
				return overlap2[axis]/100;
			}
		}

		#endregion

		#region IExtendablePointParams

		public static IExtendablePointParams ParamsExtend(IWin32Window owner, IComputationExtendingResult result, IExtendablePointParams param)
		{
			int dimension = result.PointMethodProjectiveExtensionDimension();
			IntParametersRowInfo factor = new IntParametersRowInfo(dimension,"Cell division");
	
			ParametersInputForm dialog = new ParametersInputForm(new IParametersRowInfo[] { factor});


			if (dialog.ShowDialog() == DialogResult.OK)
			{
				return new ExtendableParams(factor.Inputed);
			}
			return null;
		}

		protected class ExtendableParams : SubdevideParams, IExtendablePointParams
		{
			public ExtendableParams(int[] factor) : base(factor)
			{
			}
		}

		#endregion

		private class HomotopParams : ParamsImpl, IHomotopParams
		{
			private double[] data;

			public HomotopParams(double[] array)
			{
				this.data = array;

			}

			public double getCoordinateAt(int axis)
			{
				return data[axis];
			}

			public bool notifyNodeNotFound()
			{
				MessageBox.Show("There is no such node in Graph, Unable to continue");
				return false;
			}
		}

		public static IHomotopParams getHomotopParams(IWin32Window owner, int dimension)
		{
			DoubleParametersRow data = new DoubleParametersRow(dimension, "Coordinate");
			ParametersInputForm dialog = new ParametersInputForm(new IParametersRowInfo[] { data});

			if (dialog.ShowDialog() == DialogResult.OK)
			{
				return new HomotopParams(data.Inputed);
			}
			else
			{
				return null;
			}
		}
	}
}