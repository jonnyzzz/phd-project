#include "StdAfx.h"
#include ".\isolatingset.h"
#include "../graph/graphUtil.h"
#include <iostream>
using namespace std;


IsolatingSetProcess::IsolatingSetProcess(Graph* graphSource, Graph* startGraph, ProgressBarInfo* info) : AbstractProcessExt(graphSource, info)
{
	this->startGraph = startGraph;
}

IsolatingSetProcess::~IsolatingSetProcess(void)
{

}
void IsolatingSetProcess::processNextGraph(Graph* graph)
{
	if (!graph->equals(startGraph)) throw -1;
	
	NodeList nodeList;

	GraphNodeEnumerator ne(graph);
	Node* node;
	while (node = ne.next()) {
		nodeList.push_back(node);
	}

	processTaskList(nodeList, graph);
    
}


void IsolatingSetProcess::start() {
	submitGraphResult(startGraph);	
}


//invariant: all added nodes to NodeList should be added to graph!
void IsolatingSetProcess::processTaskList(IsolatingSetProcess::NodeList& lst, Graph* graph) {
	while (!lst.empty()) {
		Node* node = lst.front();
		lst.pop_front();

		processNode(node, lst, graph);
	}
}


void IsolatingSetProcess::processNode(Node* node, IsolatingSetProcess::NodeList& lst, Graph* graph) {

	GraphEdgeEnumerator ee(graph, node);
	Node* nodeTo;
	while( nodeTo = ee.nextTo()) {
		GraphEdgeEnumerator eee(graph, nodeTo);
		Node* nodeTest;
		while (nodeTest = eee.nextTo()) {			
			if (startGraph->findNode(nodeTest) != NULL) {
				lst.push_back(nodeTest);
				graph_result->browseTo(nodeTest);
				break;
			}
		}
	}
}