#include "StdAfx.h"
#include ".\pointgraphprocessor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


PointGraphProcessor::PointGraphProcessor(Graph* graph, ISystemFunction *function, int dimension, double* precision)
: graph(graph), dimension(dimension), pointGraph(function, dimension)
{
    x = new JDouble[dimension];
    b = new JInt[dimension+1];
    overlap1 = new JDouble[dimension];
    overlap2 = new JDouble[dimension];
    this->precision = new JDouble[dimension];
    for (int i=0; i<dimension; i++) {
        this->precision[i] = precision[i];
        overlap1[i] = precision[i];
        overlap2[i] = precision[i];
    }    
}

PointGraphProcessor::~PointGraphProcessor(void)
{
    delete[] x;
    delete[] b;
    delete[] overlap1;
    delete[] overlap2;
    delete[] precision;
}


void PointGraphProcessor::ProcessNode(Node* node) {        
    pointGraph.Reset();

    ZeroMemory(b, sizeof(JInt)*(dimension+1));

    while (b[dimension] == 0) {

        for (int i=0; i<dimension; i++) {
            x[i] = graph->toExternal(graph->getCells(node)[i],i) + (b[i] == 1?graph->getEps()[i]:0);
        }

        pointGraph.AddNodeWithAllEdges(x);

        b[0]++;
        for (int i=0; i<dimension; i++) {
            if (b[i] > 1) {
                b[i] = 0;
                b[i+1]++;
            } else {
                break;
            }
        }
    }

    pointGraph.Iterate(precision);

    const PointGraph::NodeList& list = pointGraph.Points();
    for (PointGraph::NodeList::const_iterator it = list.begin(); it != list.end(); ++it) {
        graph->addEdgeWithOverlaping(node, (*it)->valueCache, overlap1, overlap2);
    }
}