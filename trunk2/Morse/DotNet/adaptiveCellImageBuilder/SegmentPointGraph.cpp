#include "StdAfx.h"
#include ".\segmentpointgraph.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


SegmentPointGraph::SegmentPointGraph(Graph* graph, ISystemFunction* function, int dimension, size_t upperLimit) : 
PointGraph(function, dimension, upperLimit), graph(graph)
{
	ATLASSERT(dimension > 0);	
}

SegmentPointGraph::~SegmentPointGraph(void)
{
}


double SegmentPointGraph::ProjDistance(double left, double right) {

	//TODO: Include Norms
	double min1 = Abs(left - right); //x - y, (1-x) - (1-y)
	double min2 = Abs(1 - left - right); // (1-x) - y, x - (1-y)= x+y-1
	return (min1<min2)? min1 : min2;
}

bool SegmentPointGraph::NeedDevideEdge(const double* left, const double* right, const double* precision) {
	if (!graph->intersects(left, dimension) || !graph->intersects(right, dimension)) 
        return false;
	return ProjDistance(left, right) > precision[0];
}

double SegmentPointGraph::ProjDistance(const double* left, const double* right) {
	/*
	double dist;
	bool used = false;

	for (int k=0; k<dimension; k++) {
		double l = 0;		
		for (int i=0; i<dimension; i++) {
			double tmp = Abs(left[i]/left[k] - right[i]/right[k]);
			if (tmp > l) l = tmp;
		}
		if (!used || dist > l)  {
			used = true;
			dist = l;
		}
	}	
    return dist;

	//*/

	double dist = 0;
	for(int i=0; i<dimension; i++){
		double t = Abs(left[i] - right[i]);
		if (dist < t)
			dist = t;		
	}
	return dist;
}

void SegmentPointGraph::ComputeMiddle(const double* left, const double* right, double* v)
{
	/*
	int index = -1;
	double dist;

	for (int k=0; k<dimension; k++) {
		double l = 0;
		for (int i=0; i<dimension; i++) {
			double tmp = Abs(left[i]/left[k] - right[i]/right[k]);
			if (tmp > l) l = tmp;
		}
		if (index == -1  || dist > l)  {
			dist = l;
			index = k;
		}
	}

	for (int i = 0; i< dimension; i++) {
		v[i] = (left[i]/left[index] + right[i]/right[index])/2;		
	}
	//*/

	//*
	for (int i = 0; i< dimension; i++) {
		v[i] = (left[i] + right[i])/2;		
	}
	//*/
}

int SegmentPointGraph::NormalizePointExt(double* v) 
{	
	int amax = 0;
	for (int i=0; i<dimension; i++) {
		if (Abs(v[amax]) < Abs(v[i])) {
			amax = i;
		}
	}

	double tmp = v[amax];
	if (Abs(tmp) > 1e-8) {
		for (int i=0; i<dimension; i++) {
			v[i] /= tmp;
		}
	} else {
		for (int i=0; i<dimension; i++) {
			v[i] = 0;
		}
	}	

	return amax;
}

void SegmentPointGraph::NormalizePoint(double* v) {
	NormalizePointExt(v);
}


double SegmentPointGraph::EdgeLength(const double* left, const double* right) {	
	return ProjDistance(left, right);
}
void SegmentPointGraph::EdgeLength(const double* left, const double* right, double* length) {
	for (int i=0; i<dimension; i++) {
		length[i] = ProjDistance(*left++, *right++);
	}
}