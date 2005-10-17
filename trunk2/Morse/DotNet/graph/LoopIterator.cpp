#include "stdafx.h"
#include "LoopIterator.h"
#include "../graph/GraphUtil.h"

LoopIterator::LoopIterator(Graph* graph) : 
	MemoryManager(sizeof(NodeEx)*(16 + graph->getNumberOfNodes()/3)), 
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

void LoopIterator::DFSStep(NodeExList& start, NodeExList& next, NodeLists& lists) {
	next.clear();
	cout<<"DFS with "<<start.size()<<endl;
	for (NodeExList::iterator it = start.begin(); it != start.end(); it++) {
		GraphEdgeEnumerator ee(graph, (*it)->node);
		Node* to;
		while ((to = ee.nextTo()) != NULL) {
			bool contFlag = true;

			if (ReadFlag(to)) {
				NodeList list;
				//list.push_back(to);

				NodeEx* tmp = *it;
				while (tmp != NULL) {
					list.push_front(tmp->node);
					if(tmp->node == to) {
						contFlag = false;
						lists.push_back(list);
						break;
					}
					tmp = tmp->parent;
				}
			}
			if (contFlag && (*it)->number < maxSearchLength) {
				SetFlag(to, true);
				NodeEx* node = Allocate<NodeEx>();
				node->node = to;
				node->parent = *it;
				node->number = (*it)->number + 1;
				next.push_back(node);			
			}
		}
	}
}


LoopIterator::NodeLists LoopIterator::process() {

	NodeExList exList1;
	NodeExList exList2;
	NodeLists lists;

	NodeEx* ex = Allocate<NodeEx>();
	ex->node = GraphNodeEnumerator(graph).next();
	ex->parent = NULL;

	exList1.push_back(ex);

	while (!exList1.empty()) {
		DFSStep(exList1, exList2, lists);
		DFSStep(exList2, exList1, lists);
	}

	return lists;
}

