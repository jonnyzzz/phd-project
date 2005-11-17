#ifndef _ADAPTIVECELLIMAGEBULDERS_POINT_GRAPH_BUIDER_H
#define _ADAPTIVECELLIMAGEBULDERS_POINT_GRAPH_BUIDER_H

#include "PointGraph.h"

class PointGraphBuilder
{
public:
    PointGraphBuilder(int dimention, const double* eps, PointGraph& graph);
    ~PointGraphBuilder(void);

public:
    void BuildInitialGraph(double* x);

private:
    const double* eps;
    double* eps2;

    int dimension;

    PointGraph& graph;
};

#endif //_ADAPTIVECELLIMAGEBULDERS_POINT_GRAPH_BUIDER_H

