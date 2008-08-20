#include "StdAfx.h"
#include ".\msadaptivepointgraph.h"
#include <math.h>
#include "..\graph\TypeDefs.h"

MSAdaptivePointGraph::MSAdaptivePointGraph(ISystemFunction* function, int dimension, size_t upperLimit) :
PointGraph(function, dimension, upperLimit)
{
	ATLASSERT(dimension == 2);
}

MSAdaptivePointGraph::~MSAdaptivePointGraph(void)
{
}


PointGraphAction MSAdaptivePointGraph::NeedDevideEdge(const double* left, const double* right, const double* precision) {
	double v = Abs(*left++ - *right++);
	if (*precision++ <= Min( v, M_PI - v))
		return PointGraph_Devide;

	if (*precision <= Abs(*left - *right))
		return PointGraph_Devide;
	return PointGraph_NotDevide;
}


double MSAdaptivePointGraph::EdgeLength(const double* left, const double* right) {
	
	double v = Abs(*left++ - *right++);
	return Min( v, M_PI - v) + Abs(*left - *right);
}
 
void MSAdaptivePointGraph::EdgeLength(const double* left, const double* right, double* lengths) {
	double v = Abs(*left++ - *right++);
	*lengths++ = Min( v, M_PI - v);
	*lengths = Abs(*left - *right);
}

double inline MSAdaptivePointGraph::Min(double a, double b) {
	return (a>b)? b : a;
}

