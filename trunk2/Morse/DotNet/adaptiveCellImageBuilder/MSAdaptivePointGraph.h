#pragma once
#include "pointgraph.h"

class MSAdaptivePointGraph :
	public PointGraph
{
public:
	MSAdaptivePointGraph(ISystemFunction* function, int dimension, size_t upperLimit);
	virtual ~MSAdaptivePointGraph(void);


public:
	virtual PointGraphAction NeedDevideEdge(const double* left, const double* right, const double* precision);    

};
