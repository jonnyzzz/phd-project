#include "StdAfx.h"
#include ".\graphtest.h"
#include "SimpleGraphApi.h"
#include "../graph/LoopIterator.h"

GraphTest::GraphTest(void)
{
}

GraphTest::~GraphTest(void)
{
}


typedef smartPointer<Graph> SmartGraph;


void TestAndDump(SimpleGraphApi& api) {

	api.Dump();

	LoopIterator it(api.getGraph());
	LoopIterator::NodeLists lsts = it.process();

	cout<<"Dump:\n";

	int cnt = 1;
	for (LoopIterator::NodeLists::iterator it = lsts.begin(); it != lsts.end(); it++) {
		cout<<"Loop number "<<cnt++<<endl;

		for (LoopIterator::NodeList::iterator itt = it->begin(); itt != it->end(); itt++) {
			cout<<"->"<<api.extract(*itt)<<endl;
		}
		cout<<endl;
	}
}


void GraphTest::test() {
	/*
	JInt grid[] = {10,10,10};
	JDouble amin[] = {0,0,0};
	JDouble amax[] = {10,10,10};

	JDouble offset1[] = {0.3, 0.3, 0.3};
	JDouble offset2[] = {0.7, 0.7, 0.7};

	SmartGraph graph = new Graph(1, amin, amax, grid, true);

	JInt a[] = {0,0,0};
    
	Node* node = graph->browseTo(a);

	JDouble value[] = {1.5, 1.1, 1.1};

	graph->addEdgeWithOverlaping(node, value, offset1, offset2);
	*/

	SimpleGraphApi api;

	api.to(1, 2);
	api.to(2, 3);
	api.to(3, 1);

	TestAndDump(api);

	api.to(3,4);
	api.to(4,5);
	api.to(5,5);

	TestAndDump(api);

	api.to(5,1);

	TestAndDump(api);

}