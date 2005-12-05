#ifndef _ADAPTIVECELLIMAGEBULDERS_POINT_GRAPH_BUIDER_H
#define _ADAPTIVECELLIMAGEBULDERS_POINT_GRAPH_BUIDER_H

#include "PointGraph.h"

class PointGraphBuilder
{
public:
    PointGraphBuilder(int ldimension, int udimention, const double* eps, PointGraph& graph);
    ~PointGraphBuilder(void);

public:
    void BuildInitialGraph(double* x);

private:
    double* eps;
    double* eps2;

    const int udimension;
	const int ldimension;

	const int dim;

    PointGraph& graph;
};

#endif //_ADAPTIVECELLIMAGEBULDERS_POINT_GRAPH_BUIDER_H

