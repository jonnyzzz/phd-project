#include "StdAfx.h"
#include ".\isolatingset.h"
#include "../graph/graphUtil.h"
#include <iostream>
using namespace std;

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif


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

	bool b = false;
	do {

		cout<<"Start Againyyyyy\n";

		GraphNodeEnumerator ne(graph_result);
		Node* node;
		while (node = ne.next()) {
			nodeList.push_back(node);
		}

		b = processTaskList(&nodeList, graph);

	} while (b);
    
}


void IsolatingSetProcess::start() {
	AbstractProcessExt::start();

	submitGraphResult(startGraph->copyCoordinates());
	GraphNodeEnumerator ne(startGraph);
	Node* node; 
	while(node = ne.next()) {
		graph_result->browseTo(node);
	}
}


//invariant: all added nodes to NodeList should be added to graph!
bool IsolatingSetProcess::processTaskList(IsolatingSetProcess::NodeList* lst, Graph* graph) {
	bool b = false;
	while (!lst->empty()) {
		Node* node = lst->back();
		lst->pop_back();
		
		b = b || processNode(graph->findNode(node), lst, graph);
		
	}

	return b;
}


bool IsolatingSetProcess::processNode(Node* node, IsolatingSetProcess::NodeList* lst, Graph* graph) {

	if (node == NULL) {
		cout<<"Fail!\n";
		return false;
	}

	cout<<"Start for node "<<graph->getCells(node)[0]<<"\n";

	bool b = false;

	GraphEdgeEnumerator ee(graph, node);
	Node* nodeTo;
	while( nodeTo = ee.nextTo()) {
		
		if (graph_result->findNode(nodeTo) == NULL){

			GraphEdgeEnumerator eee(graph, nodeTo);
			Node* nodeTest;
			while (nodeTest = eee.nextTo()) {			
				
				if (graph_result->findNode(nodeTest) != NULL) {
					
					Node* tmp = graph_result->browseTo(nodeTo);

					lst->push_back(tmp);
					lst->push_back(tmp);
					lst->push_back(tmp);
					lst->push_back(tmp);
					lst->push_back(tmp);
					lst->push_back(tmp);
					
					cout<<"Added node "<<graph->getCells(nodeTo)[0]<<"\n";

					b = true;
					break;
				}
			}
		}
	}
	return b;
}