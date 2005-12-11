#pragma once
#include "PointGraph.h"
#include "../graph/Graph.h"

class SegmentPointGraph : public PointGraph
{
public:
	SegmentPointGraph(Graph* graph, ISystemFunction* function, int dimension, size_t upperLimit);
	virtual ~SegmentPointGraph(void);

protected:
    virtual bool NeedDevideEdge(const double* left, const double* right, const double* precision);    
    virtual double EdgeLength(const double* left, const double* right);
    virtual void EdgeLength(const double* left, const double* right, double* lengths);

	virtual void ComputeMiddle(const double* left, const double* right, double* v);

public:
	virtual void NormalizePoint(double* v);

	int NormalizePointExt(double* v);

protected:
	double ProjDistance(const double* left, const double* right);
	double ProjDistance(double x, double y);

private:	
	Graph* graph;
};
