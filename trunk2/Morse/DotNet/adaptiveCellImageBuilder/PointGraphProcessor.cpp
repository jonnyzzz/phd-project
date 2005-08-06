#include "StdAfx.h"
#include ".\pointgraphprocessor.h"

PointGraphProcessor::PointGraphProcessor(Graph* graph, ISystemFunction *function, int dimension)
: graph(graph), dimension(dimension), pointGraph(function, dimension)
{
    x = new JDouble[dimension];
    b = new JInt[dimension+1];
}

PointGraphProcessor::~PointGraphProcessor(void)
{
    delete[] x;
    delete[] b;
}


void PointGraphProcessor::ProcessNode(Node* node) {        
    pointGraph.Reset();

    ZeroMemory(b, sizeof(JInt)*(dimension+1));

    while (b[dimension] == 0) {

        for (int i=0; i<dimension; i++) {
            x[i] = graph->toExternal(graph->getCells(node)[i],i) + graph->getEps()[i]*b[i];
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