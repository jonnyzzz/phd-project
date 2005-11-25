using System;
using System.Xml.Serialization;
using Eugene.Petrenko.Gui2.MethodComparer.Actions;
using EugenePetrenko.Gui2.Kernell2.Document;
using EugenePetrenko.Gui2.Kernell2.Node;

namespace Eugene.Petrenko.Gui2.MethodComparer.Parameters
{
	/// <summary>
	/// Summary description for XMLMethodParameters.
	/// </summary>
	/// 
	public class XMLMethodParameters : MethodParametersBase, IMethodParameters
	{
	    private int dimension;
	    private int[] subdivision;
	    private int[] numberOfPointsP;
	    private double[] offset;
	    private int numberOfSteps;
	    private int[] translatePrecision;
	    private bool boxUseDerivate;
	    private Function function;
	    private int adaptiveLimit;
	    private string caption;
	    private bool needResolveEdges;

	    public XMLMethodParameters(int dimension, int[] subdivision, int[] numberOfPointsP, double[] offset, int numberOfSteps, int[] translatePrecision, bool boxUseDerivate, Function function, int adaptiveLimit, string caption, bool needResolveEdges)
	    {
	        this.dimension = dimension;
	        this.subdivision = subdivision;
	        this.numberOfPointsP = numberOfPointsP;
	        this.offset = offset;
	        this.numberOfSteps = numberOfSteps;
	        this.translatePrecision = translatePrecision;
	        this.boxUseDerivate = boxUseDerivate;
	        this.function = function;
	        this.adaptiveLimit = adaptiveLimit;
	        this.caption = caption;
	        this.needResolveEdges = needResolveEdges;
	    }

	    public int NumberOfSteps
	    {
	        get { return numberOfSteps; }
	    }

	    public int Dimension
	    {
	        get { return dimension; }
	    }

	    public int Subdivision(int index)
	    {
	        return subdivision[index];
	    }

	    public int NumberOfPoints(int index)
	    {
	        return numberOfPointsP[index];
	    }

	    public double PointMethodOffset(int index)
	    {
	        return offset[index];
	    }

	    public int TranslatePrecisionDevider(int index)
	    {
	        return translatePrecision[index];
	    }

	    public string Caption
	    {
	        get { return caption; }
	    }

	    public bool BoxMethodUseDerivative()
	    {
	        return boxUseDerivate;
	    }

	    public bool NeedResolveEdges()
	    {
	        return needResolveEdges;
	    }

	    public override Function GetSystemFunction()
	    {
	        return function;
	    }

	    public int AdaptiveUpperLimit()
	    {
	        return adaptiveLimit;
	    }
	}
}
