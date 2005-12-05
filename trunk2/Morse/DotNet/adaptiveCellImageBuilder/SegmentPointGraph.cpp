#include "StdAfx.h"
#include ".\segmentpointgraph.h"

SegmentPointGraph::SegmentPointGraph(Graph* graph, ISystemFunction* function, int dimension, size_t upperLimit) : PointGraph(function, dimension, upperLimit), graph(graph)
{
	int base_dim = dimension/2;
}

SegmentPointGraph::~SegmentPointGraph(void)
{
}


double SegmentPointGraph::ProjDistance(double left, double right) {
	double min1 = Abs(left - right); //x - y, (1-x) - (1-y)
	double min2 = Abs(1 - left - right); // (1-x) - y, x - (1-y)= x+y-1
	return (min1<min2)? min1:min2;
}
bool SegmentPointGraph::NeedDevideEdge(const double* left, const double* right, const double* precision) {
    if (!graph->intersects(left) || !graph->intersects(right)) 
        return false;

	for (int i=0; i<base_dim; i++) {
		if (Abs(*left++ - *right++) > *precision++) return true;
	}
	for (int i=0; i<base_dim; i++) {		
		double min = ProjDistance(*left++, *right++);
		if (min > precision[i]) return true;
	}
	return false;
}

double SegmentPointGraph::ProjDistance(const double* left, const double* right) {

	double dist;
	bool used = false;

	for (int k=0; k<base_dim; k++) {
		double l = 0;
		for (int i=0; i<base_dim; i++) {
			l += Abs(left[i]/left[k] - right[i]/right[k]);
		}
		if (!used || dist < l) 
			dist = l;
	}
    return dist;
}

double SegmentPointGraph::EdgeLength(const double* left, const double* right) {

	double length = 0;
	for (int i=0; i<base_dim; i++) {
		length += Abs(*left++ - *right++);
	}
	return length + ProjDistance(&left[base_dim], &right[base_dim]);
}
void SegmentPointGraph::EdgeLength(const double* left, const double* right, double* length) {
	for (int i=0; i<base_dim; i++) {
		length[i] = Abs(*left++ - *right++);
	}
	for (int i=0; i<base_dim; i++) {
		length[i] = ProjDistance(*left++, *right++);
	}
}