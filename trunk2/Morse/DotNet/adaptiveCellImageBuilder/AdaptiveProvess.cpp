#include "StdAfx.h"
#include ".\adaptiveprovess.h"
#include "..\graph\graphUtil.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


AdaptiveProvess::AdaptiveProvess(ISystemFunction* function, Graph* graph, JInt* division, double precision, ProgressBarInfo* info)
: AbstractProcess(info), rootGraph(graph), function(function)
{
    this->dimension = graph->getDimention();
    this->resultGraph = graph->copyCoordinatesDevided(division);
    this->division = new int[dimension];
    this->x = new JInt[dimension];
    this->b = new JInt[dimension+1];

    for (int i=0; i<dimension; i++) this->division[i] = division[i];
    processor = new PointGraphProcessor(this->resultGraph, function, dimension, precision);
}

AdaptiveProvess::~AdaptiveProvess(void)
{
    delete[] division;
    delete[] x;
    delete[] b;
    delete processor;
}


GraphSet AdaptiveProvess::results() {
    return GraphSet(resultGraph);
}


void AdaptiveProvess::processNextGraph(Graph* graph) {

    GraphNodeEnumerator en(graph);
    Node* node;
    while (node = en.next()) {
        processNode(graph, node);
    }
}

void AdaptiveProvess::processNode(Graph* graph, Node* node) {
    
    ZeroMemory(b, sizeof(JInt)*(dimension+1));

    while (b[dimension] == 0) {
        for (int i=0; i<dimension; i++) {
            x[i] = graph->getCells(node)[i]*division[i] + b[i];
        }

        Node* resultNode = resultGraph->browseTo(x);
        processResultNode(resultNode);
        
        b[0]++;
        for (int i=0; i<dimension; i++) {
            if (b[i] >= division[i]) {
                b[i] = 0;
                b[i+1] ++;
            } else {
                break;
            }
        }
    }
}

void AdaptiveProvess::processResultNode(Node* node) {    
    processor->ProcessNode(node);
}