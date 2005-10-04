#include "StdAfx.h"
#include ".\graphtest.h"

GraphTest::GraphTest(void)
{
}

GraphTest::~GraphTest(void)
{
}


typedef smartPointer<Graph> SmartGraph;

void GraphTest::test() {
	JInt grid[] = {10,10,10};
	JDouble amin[] = {0,0,0};
	JDouble amax[] = {10,10,10};

	JDouble offset1[] = {0.3, 0.3, 0.3};
	JDouble offset2[] = {0.7, 0.7, 0.7};

	SmartGraph graph = new Graph(1, amin, amax, grid);

	JInt a[] = {0,0,0};
    
	Node* node = graph->browseTo(a);

	JDouble value[] = {1.5, 1.1, 1.1};

	graph->addEdgeWithOverlaping(node, value, offset1, offset2);
	

}