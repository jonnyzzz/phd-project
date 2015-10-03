#pragma once
#include "PointGraph.h"
#include "../graph/Graph.h"

class IntersectingPointGraph :
	public PointGraph
{
public:
	IntersectingPointGraph(Graph* graph, ISystemFunction* function, int dimension, size_t upperLimit);
	virtual ~IntersectingPointGraph(void);
        
private:
    Graph* graph;
private:
    double Abs(double x);
protected:
    virtual PointGraphAction NeedDevideEdge(const double* left, const double* right, const double* precision);
};
