#include "StdAfx.h"
#include ".\intersectingpointgraph.h"

IntersectingPointGraph::IntersectingPointGraph(Graph* graph, ISystemFunction* function, int dim, size_t upperLimit) :PointGraph(function, dim, upperLimit), graph(graph)
{
}

IntersectingPointGraph::~IntersectingPointGraph(void)
{
}


double inline IntersectingPointGraph::Abs(double x) {
    return (x>0)?x:-x;
}

bool IntersectingPointGraph::NeedDevideEdge(const double* left, const double* right, const double* precision) {
    if (!graph->intersects(left) || !graph->intersects(right)) 
        return false;
    for (int i=0;i<dimension; i++) {
        if (Abs(left-right) > precision[i]) return false;
    }
    return true;
}