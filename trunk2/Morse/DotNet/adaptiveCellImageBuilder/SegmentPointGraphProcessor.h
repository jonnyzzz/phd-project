#pragma once
#include "../SystemFunction/ISystemFunction.h"
#include <list>
using namespace std;
class PointGraph;
class SegmentPointGraph;

#include "../graph/Graph.h"
#include "PointGraphBuilder.h"
#include "SegmentPointGraphBuilder.h"
#include "../SystemFunction/SegmentProjectiveExtendedSystemFunction.h"

class SegmentPointGraphProcessor
{
public:
    SegmentPointGraphProcessor(Graph* graph, SegmentProjectiveExtendedSystemFunction  *function, int dimension, double* precision, size_t upperLimit);
    virtual ~SegmentPointGraphProcessor(void);

public:
    typedef list<double*> PointsList;

    void ProcessNode(Node* node);

private:
    void AddCheckedNode(Node* graphNode, double* base, double* proj);
	void AddNonCheckedNode(Node* graphNode, PointGraph::Node* base, PointGraph::Node* proj);
    

private:
	void Concatinate(const double* left, const double* right, double* x);


private:

	SegmentProjectiveExtendedSystemFunction* function;
	double* input;
	double* output;

    Graph* graph;
    int dimension;
	int dimensionBase;

    PointGraph* pointGraphBase; 
	SegmentPointGraph* pointGraphProj;
    PointGraphBuilder pointGraphBuilderBase;
	SegmentPointGraphBuilder pointGraphBuilderProj;

    JDouble* x;
    JDouble* x0;
    JDouble* radius;
    JInt* b;
    JInt* a;
	JInt* dGrid;
    
    double* precision;
    double* overlap1;
    double* overlap2;  
};
