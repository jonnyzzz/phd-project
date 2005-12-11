#include "StdAfx.h"
#include ".\pointgraphprocessor.h"
#include "IntersectingPointGraph.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


PointGraphProcessor::PointGraphProcessor(Graph* graph, ISystemFunction *function, int dimension, double* precision, size_t upperLimit)
: graph(graph), dimension(dimension), pointGraph(new IntersectingPointGraph(graph, function, dimension, upperLimit)),
  pointGraphBuilder(0, dimension, graph->getEps(), pointGraph)
{
	ATLASSERT(dimension > 0);

    x = new JDouble[dimension];
    x0 = new JDouble[dimension];
    b = new JInt[dimension+1];
    a = new JInt[dimension+1];
    overlap1 = new JDouble[dimension];
    overlap2 = new JDouble[dimension];
    this->precision = new JDouble[dimension];
    for (int i=0; i<dimension; i++) {
        this->precision[i] = precision[i];
        overlap1[i] = precision[i];
        overlap2[i] = precision[i];
    }    
    radius = new JDouble[dimension];
}

PointGraphProcessor::~PointGraphProcessor(void)
{
    delete[] x;
    delete[] x0;
    delete[] a;
    delete[] b;
    delete[] overlap1;
    delete[] overlap2;
    delete[] precision;
    delete[] radius;
	delete pointGraph;
}


void PointGraphProcessor::ProcessNode(Node* node) {        
    pointGraph->Reset();

    for (int i=0; i<dimension; i++) {
        x[i] = graph->toExternal(graph->getCells(node)[i],i);
    }   
    pointGraphBuilder.BuildInitialGraph(x);
    
    if (pointGraph->Iterate(precision)) {
        const PointGraph::NodeList& list = pointGraph->Points();        
        for (PointGraph::NodeList::const_iterator it = list.begin(); it != list.end(); ++it) {
            AddCheckedNode(node, *it);
        }
    } else {
        const PointGraph::NodeList& list = pointGraph->Points();        
        for (PointGraph::NodeList::const_iterator it = list.begin(); it != list.end(); ++it) {
            PointGraph::Node* pnode = *it;

            if (pointGraph->IsCheckedNode(pnode)) {            
                AddCheckedNode(node, pnode);
            } else {
                AddNotCheckedNode(node, pnode);
            }
        }
    }
}

void PointGraphProcessor::AddCheckedNode(Node* graphNode, PointGraph::Node* node) {
    graph->addEdgeWithOverlaping(graphNode, node->valueCache, overlap1, overlap2);
}

void PointGraphProcessor::AddNotCheckedNode(Node* graphNode, PointGraph::Node* node) {
    pointGraph->NodeLength(node, radius);

    graph->addEdgesRadius(graphNode, node->valueCache, radius);
}