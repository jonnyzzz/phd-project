#include "stdafx.h"
#include "LoopIterator.h"
#include "../graph/GraphUtil.h"

LoopIterator::LoopIterator(Graph* graph) : 
	MemoryManager(sizeof(NodeEx)*(16 + graph->getNumberOfNodes()/3)), graph(graph), flagID(graph->registerFlag())
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

void LoopIterator::DFSStep(Node* root, NodeExList& start, NodeExList& next, NodeLists& lists) {	
	next.clear();
	cout<<"DFS with "<<start.size()<<endl;
	for (NodeExList::iterator it = start.begin(); it != start.end(); it++) {
		GraphEdgeEnumerator ee(graph, (*it)->node);
		Node* to;
		while ((to = ee.nextTo()) != NULL) {

			if (ReadFlag(to)) {
				if (to == root) {
					NodeList list;					
					NodeEx* tmp = *it;
					while (tmp != NULL) {
						list.push_front(tmp->node);						
						tmp = tmp->parent;					
					}													
					lists.push_back(list);				
				}
			} else {			
				SetFlag(to, true);				
				NodeEx* node = Allocate<NodeEx>();
				node->node = to;
				node->parent = *it;
				next.push_back(node);			
			}
		}
	}
}


LoopIterator::NodeLists LoopIterator::process() {

	NodeExList exList1;
	NodeExList exList2;
	NodeLists lists;

	GraphNodeEnumerator ne (graph);
	Node* node;
	while ((node = ne.next()) != NULL) {
		exList1.clear();
		exList2.clear();

		NodeEx* ex = Allocate<NodeEx>();
		ex->node = node;
		ex->parent = NULL;

		exList1.push_back(ex);

		while (!exList1.empty()) {
			cout<<".";
			DFSStep(node, exList1, exList2, lists);
			cout<<".";
			DFSStep(node, exList2, exList1, lists);
		}
		ResetFlags();
	}
	
	return lists;
}





