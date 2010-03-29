#include "stdafx.h"
#include "LoopIterator.h"
#include "../graph/GraphUtil.h"

/*
#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif
*/


LoopIterator::LoopIterator(Graph* graph) : 
	ExtendedMemoryManager(sizeof(NodeEx)*(16 + graph->getNumberOfNodes()/3)), 
	graph(graph), 
	flagID(graph->registerFlag()), 
	flagIDLoop(graph->registerFlag()), 
	maxSearchLength(graph->getNumberOfNodes() + 1)
{
}

LoopIterator::~LoopIterator(void)
{
	graph->unregisterFlag(flagID);
}

void LoopIterator::SetFlag(Node* node, bool value) {
	graph->setFlag(node, flagID, value);
}

bool LoopIterator::ReadFlag(Node* node) {
	return graph->readFlag(node, flagID);
}

void LoopIterator::ResetFlags() {
	GraphNodeEnumerator ne(graph);
	Node* node;
	while ((node = ne.next()) != NULL) {
		SetFlag(node, false);
	}
}

bool LoopIterator::ReadVisitedFlag(Node* node) {
	return graph->readFlag(node, flagIDLoop);
}

void LoopIterator::SetVisitedFlag(Node* node) {
	graph->setFlag(node, flagIDLoop, true);
}



LoopIterator::NodeLists LoopIterator::process() {
	Node* node = GraphNodeEnumerator(graph).next();
	//SetFlag(node, true);
	NodeEx* init = ALLOCATE_DISPOSABLE(NodeEx, (graph, node, NULL, 0) );

	NodeLists list;

	while (init != NULL) {
		init = DeepSearch(init, list);
	}

	return list;

}


LoopIterator::NodeEx* LoopIterator::FindNextPath(LoopIterator::NodeEx* node) {
	if (node == NULL) return NULL;

	if (node->deep >= maxSearchLength) {
		SetFlag(node->node, false);
		node = node->parent;
	}

	Node* ret = NULL;
	NodeEx* prev = node;

	while (ret == NULL && node != NULL) {
		ret = node->ee.nextTo();
		if (ret == NULL) {
			SetFlag(node->node, false);
		}
		prev = node;
		node = node->parent;		
	}
	
	if (ret != NULL) {	
		SetFlag(prev->node, true);
		return ALLOCATE_DISPOSABLE(NodeEx, (graph, ret, prev, prev->deep + 1) );
	} else {
		return NULL;
	}
}



LoopIterator::NodeEx* LoopIterator::DeepSearch(LoopIterator::NodeEx* startNode, LoopIterator::NodeLists& lists) {
	Node* node = startNode->node;

	//cout<<"Node: "<<graph->getCells(node)[0]<<" "<<((ReadFlag(node))? "TRUE":"FALSE")<< "  ";
	//if (startNode->parent != NULL) {
	//	cout<< graph->getCells(startNode->parent->node)[0]<<endl;
	//} else {
	//	cout<<endl;
	//}

	if (startNode->deep >= maxSearchLength) return FindNextPath(startNode);	
	
	if (ReadFlag(node)) {
		NodeList list;
		NodeEx* tmp = startNode->parent;
		while (tmp != NULL) {
			list.push_front(tmp->node);
			if (tmp->node == node) break;
			tmp = tmp->parent;
		}
		lists.push_back(list);
		return FindNextPath(startNode->parent);
	} else {
		return FindNextPath(startNode);
	}	
}
	



