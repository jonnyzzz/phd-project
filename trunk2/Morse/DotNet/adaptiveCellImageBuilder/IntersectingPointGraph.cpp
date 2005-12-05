#include "StdAfx.h"
#include ".\intersectingpointgraph.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


IntersectingPointGraph::IntersectingPointGraph(Graph* graph, ISystemFunction* function, int dim, size_t upperLimit) :PointGraph(function, dim, upperLimit), graph(graph)
{
	ATLASSERT(dim > 0);
}

IntersectingPointGraph::~IntersectingPointGraph(void)
{
}


double inline IntersectingPointGraph::Abs(double x) {
    return (x>0)?x:-x;
}

bool IntersectingPointGraph::NeedDevideEdge(const double* left, const double* right, const double* precision) {
	if (!graph->intersects(left, 0, dimension) || !graph->intersects(right, 0, dimension)) 
        return false;
    for (int i=0;i<dimension; i++) {
        if (Abs(left-right) > precision[i]) return false;
    }
    return true;
}