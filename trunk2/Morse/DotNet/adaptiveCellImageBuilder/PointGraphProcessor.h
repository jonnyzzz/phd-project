#pragma once

#include "..\systemFunction\ISystemFunction.h"
#include <list>
using namespace std;
#include "pointGraph.h"
#include "..\graph\graph.h"

class PointGraphProcessor
{
public:
    PointGraphProcessor(Graph* graph, ISystemFunction *function, int dimension, double precision);
    ~PointGraphProcessor(void);

public:
    typedef list<double*> PointsList;

    void ProcessNode(Node* node);

private:
    PointGraph pointGraph;
    Graph* graph;
    int dimension;

    JDouble* x;
    JInt* b;

    double precision;
    double* overlap1;
    double* overlap2;
    
};
