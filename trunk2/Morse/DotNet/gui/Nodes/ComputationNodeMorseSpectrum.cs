using System;
using System.Windows.Forms;
using System.Collections;
using MorseKernelATL;

namespace gui
{
	/// <summary>
	/// Summary description for ComputationNodeMorseSpectrum.
	/// </summary>
	public class ComputationNodeMorseSpectrum : ComputationNode
	{
		private CMorseSpectrum morse;
		
		public ComputationNodeMorseSpectrum(CMorseSpectrum morse)
		{
			this.morse = morse;
			this.Text = string.Format("Morse Spectrum: [{0}, {1}]", morse.lowerBound, morse.upperBound);	
		}

		protected override ComputationNodeMenuItem[] getMenuItems()
		{
			return new ComputationNodeMenuItem[]{};		
		}

		#region NodeInformation implementations...
		public override string getInfoEdges()
		{
			return "";
		}

		public override string getInfoGridNumber()
		{
			return "";
		}

		public override string getInfoGridSize()
		{
			return "";
		}

		public override string getInfoNodes()
		{
			return string.Format("{0}; {1}", morse.lowerLength, morse.upperLength);
		}

		public override string getInfoSpace()
		{
			return string.Format("[{0}, {1}]", morse.lowerBound, morse.upperBound);
		}
		#endregion

	}
}
