#include "StdAfx.h"
#include ".\graphmultiplicator.h"
#include ".\nodeMultiplicator.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif




GraphMultiplicator::GraphMultiplicator(Graph* graph, int* factors) :
	graph(graph)
{
	dimension = graph->getDimention();
	nodeMultiplicator = new NodeMultiplicator(dimension, graph->getEps(), factors);
	nodeEnumerator = graph->getNodeRoot();
	x0 = new JDouble[dimension];
}

GraphMultiplicator::~GraphMultiplicator(void)
{
	graph->freeNodeEnumerator(nodeEnumerator);
	delete nodeMultiplicator;
	delete[] x0;
}


void GraphMultiplicator::setCoordinatePointer(JDouble* c) {
	nodeMultiplicator->setCoordinateReturn(c);
}

void GraphMultiplicator::init_center() {	
	for (int i=0; i<dimension; i++) {		
		x0[i] = graph->toExternal(graph->getCells(node)[i], i);
	}
	nodeMultiplicator->start(x0);
}
	
bool GraphMultiplicator::next_node() {
	if (!(node = graph->getNode(nodeEnumerator))) return false;

	init_center();

	return next_point();
}

bool GraphMultiplicator::next_point() {
	return nodeMultiplicator->next();
}

bool GraphMultiplicator::next() {
	
	return next_point() || next_node();
}

Node* GraphMultiplicator::currentNode() {
	return node;
}