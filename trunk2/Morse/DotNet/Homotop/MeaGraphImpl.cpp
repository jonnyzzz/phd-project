#include "StdAfx.h"
#include ".\meagraphimpl.h"

MeaGraphImpl::MeaGraphImpl(void) 
{
	JDouble min = 0;
	JDouble max = 1;
	JInt grid = 100;
	myGraph = new Graph(1, &min, &max, &grid);
	myNodeCounter = 0;
}

MeaGraphImpl::MeaGraphImpl(Graph* graph) 
{			
	myGraph = graph;
	isExternalGraph = true;
}

MeaGraphImpl::~MeaGraphImpl(void)
{	
	for (unsigned int i = 0; i<myNodes.size(); i++){
		MeaNode* nextNode = myNodes[i];
		delete nextNode;
	}
	if (isExternalGraph != true){
		delete myGraph;
	}
}

int MeaGraphImpl::getNodeCount(void) const {
	return myGraph->getNumberOfNodes();
}

MeaNode& MeaGraphImpl::addNode(void) {
	//J: Is this graph's dimenstion SHOLD be eqals to 1 any way?
	JInt cell[] = {myNodeCounter++};	
	Node* hisNode = myGraph->browseTo(cell); //<- this call is unpredictable if myGraph's dimension > 1
	assert(hisNode != NULL);
	MeaNode* newMeaNode = wrapNode(hisNode);	
	return *newMeaNode;
}

MeaNode* MeaGraphImpl::findNode(Node* hisNode) {
	for (unsigned int i=0; i<myNodes.size(); i++) {
		MeaNode* nextNode = myNodes[i];
		if (nextNode->myNode==hisNode) {
			return nextNode;
		}
	}
	return NULL;
}

MeaNode* MeaGraphImpl::begetNode(Node* hisNode)
{
	MeaNode* result = findNode(hisNode);
	if (result == NULL){
		result = wrapNode(hisNode);
	}
	return result;
}

MeaNode* MeaGraphImpl::wrapNode(Node* hisNode) {
	MeaNode* result = new MeaNode(this, hisNode, myGraph);
	myNodes.push_back(result);
	return result;
}

