#pragma once

#include "../SystemFunction/ISystemFunction.h"
#include <list>
using namespace std;
#include "PointGraph.h"
#include "../graph/Graph.h"
#include "PointGraphBuilder.h"

class PointGraphProcessor
{
public:
    PointGraphProcessor(Graph* graph, ISystemFunction *function, int dimension, double* precision, size_t upperLimit);
    virtual ~PointGraphProcessor(void);

public:
    typedef list<double*> PointsList;

    void ProcessNode(Node* node);

private:
    void AddCheckedNode(Node* graphNode, PointGraph::Node* node);
    void AddNotCheckedNode(Node* graphNode, PointGraph::Node* node);

private:


private:
    PointGraph* pointGraph;    
    PointGraphBuilder pointGraphBuilder;
    Graph* graph;
    int dimension;

    JDouble* x;
    JDouble* x0;
    JDouble* radius;
    JInt* b;
    JInt* a;

    double* precision;
    double* overlap1;
    double* overlap2;    
};
