using System;
using Eugene.Petrenko.Gui2.MethodComparer.Actions;
using EugenePetrenko.Gui2.Kernell2.Actions;
using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace Eugene.Petrenko.Gui2.MethodComparer.Parameters
{
	/// <summary>
	/// Summary description for MethodParameters.
	/// </summary>
	public abstract class MethodParameters : MethodParametersBase, IMethodParameters
	{
	    public int NumberOfSteps
	    {
	        get { return 5; }
	    }

	    public int Dimension
	    {
	        get { return 2; }
	    }

	    public string Caption
	    {
	        get { return "MethodParameters"; }
	    }

	    public int Subdivision(int index)
		{
		    return 2;
		}

        public int NumberOfPoints(int index)
        {
            return 5;
        }

        public double PointMethodOffset(int index)
        {
            return 0.20;
        }

        public int TranslatePrecisionDevider(int index)
        {
            return Subdivision(index);
        }        

        public bool BoxMethodUseDerivative()
        {
            return true;
        }

        public bool NeedResolveEdges()
        {
            return true;
        }

	    public int AdaptiveUpperLimit()
	    {
	        return 0;
	    }
	}
}
