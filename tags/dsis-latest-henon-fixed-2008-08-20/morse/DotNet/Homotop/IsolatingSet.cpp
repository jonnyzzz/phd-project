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

		//cout<<"--->Start Again\n";

		GraphNodeEnumerator ne(graph_result);
		Node* node;
		while (node = ne.next()) {
			nodeList.push_back(node);
		}

		b = processTaskList(nodeList, graph);

	} while (b);
    
}


void IsolatingSetProcess::start() {
	AbstractProcessExt::start();

	submitGraphResult(startGraph->copyCoordinates(false));
	GraphNodeEnumerator ne(startGraph);
	Node* node; 
	while(node = ne.next()) {
		graph_result->browseTo(node);
	}
}


//invariant: all added nodes to NodeList should be added to graph!
bool IsolatingSetProcess::processTaskList(IsolatingSetProcess::NodeList& lst, Graph* graph) {
	NodeList l2;
	bool b = false;	
	do {
		while (!lst.empty()) {
			Node* node = lst.front();
			lst.pop_front();
			
			processNode(graph->findNode(node), lst, l2, graph);
			b |= !l2.empty();			
		}	
		lst = l2;
		l2.clear();
	} while (!lst.empty());
	
	return b;
}

//out is treated as cache. So this proceduce SHOULD not clear it up.
void IsolatingSetProcess::processNode(Node* node, NodeList& lst, NodeList& out, Graph* graph) {
	
	if (node == NULL) {
		cout<<"Fail!\n";
		return;
	}

	//cout<<"Start for node "<<graph->getCells(node)[0]<<"\n";

	GraphEdgeEnumerator ee(graph, node);
	Node* nodeTo;
	while( nodeTo = ee.nextTo()) {
		
		if (graph_result->findNode(nodeTo) == NULL){

			GraphEdgeEnumerator eee(graph, nodeTo);
			Node* nodeTest;
			while (nodeTest = eee.nextTo()) {			
				
				if (graph_result->findNode(nodeTest) != NULL) {
					
					Node* tmp = graph_result->browseTo(nodeTo);

					out.push_back(tmp);
					
					//cout<<"Added node "<<graph->getCells(nodeTo)[0]<<"\n";

					break;
				}
			}
		}
	}
}