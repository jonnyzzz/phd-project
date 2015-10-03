#include "StdAfx.h"
#include ".\minimallooptest.h"
#include "../homotop/minimalLoopFinder.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


MinimalLoopTest::MinimalLoopTest(ostream& o) : TestBase("Minimal Loop Test", o)
{
}

MinimalLoopTest::~MinimalLoopTest(void)
{
}


Node*  MinimalLoopTest::to(int index) {
	return graph->browseTo(&index);
}

void MinimalLoopTest::to(int f, int t) {
	graph->browseTo(to(f), to(t));
}

void MinimalLoopTest::testOneAnswer(int id, Graph* result) {
	AssertTrue(result->getNumberOfNodes() == 1, "Wrong number of nodes");
	GraphNodeEnumerator ne(result);
	Node* node;
	while(node = ne.next()) {
		AssertTrue(graph->findNode(node) == graph->browseTo(to(1)), "Wrong node in result");
	}
}

void MinimalLoopTest::Test() {	
	JDouble vmin[] = {0,};
	JDouble vmax[] = {1,};
	JInt	grid[] = {1000};

	graph = new Graph(1,vmin, vmax, grid, true);


	to(1, 1);
	to(1, 2);
	to(2, 3);
	to(3, 2);
	to(3, 1);
	to(2, 1);
	to(1, 7);
	to(7, 8);
	to(8, 9);
	to(9, 1);
	to(8, 3);
	to(3, 9);
	to(7, 1);
	to(2, 7);


	MinimalLoopFinder f;
	Graph* result = f.FindMinimalLoop(graph, to(1));

	testOneAnswer(1, result);
	delete result;

	result = f.FindMinimalLoop(graph, to(2));
	delete result;

	result = f.FindMinimalLoop(graph, to(3));
	delete result;

	result = f.FindMinimalLoop(graph, to(9));
	AssertTrue(result->getNumberOfNodes() == 4, "Incorrect loop length");

	delete graph;	
}
