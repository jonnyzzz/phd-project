#include "StdAfx.h"
#include ".\isolatingset.h"
#include "meagraphimpl.h"
#include "meagraphalgorithm.h"
#include "meagraph.h"

IsolatingSetProcess::IsolatingSetProcess(Graph* graphSource, Node* startNode): AbstractProcess(graphSource)
{
	myStartNode = startNode;
}

IsolatingSetProcess::~IsolatingSetProcess(void)
{
}
void IsolatingSetProcess::processNextGraph(Graph* graph)
{
}

void IsolatingSetProcess::start(void)
{
	Graph* copy = graph_source->copyCoordinates();
	//J: copy->getDimention() can be > 1
	MeaGraph* meaGraph = new MeaGraphImpl(copy);
	MeaNode* startNode = meaGraph->begetNode(myStartNode);
	MeaNodeSet resultSet = runProcess(*startNode);
	importData(resultSet,copy);
	delete meaGraph;
	submitGraphResult(copy);
}

MeaNodeSet IsolatingSetProcess::runProcess(MeaNode& startNode)
{
	MeaGraphAlgorithm algorithm;
	MeaNodeSet result = algorithm.searchContour(startNode);
	return result;
}

//TODO:
//here the algorithm has the knowledge about internals of Node and Graph
//It needs refactoring (e.g. move this implementation into MeaGraphImpl.exportTo(Graph*))
void IsolatingSetProcess::importData(MeaNodeSet from, Graph* into)
{
	for (MeaNodeSet::iterator it = from.begin(); it!=from.end(); it++) {
		MeaNode* nextNode = *it;
		Node* nextHisNode = nextNode->getHisNode();
		into->browseTo(into->getCells(nextHisNode));			
		//into->importNode(nextHisNode);
	}
}
