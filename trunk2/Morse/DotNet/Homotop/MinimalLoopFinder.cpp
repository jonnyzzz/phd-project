#include "StdAfx.h"
#include ".\minimalloopfinder.h"
#include "../graph/graph.h"
#include "../graph/graphUtil.h"


MinimalLoopFinder::MinimalLoopFinder() {
	InitHeap();
}

MinimalLoopFinder::~MinimalLoopFinder() {
	DisposeHeap();
}

Graph* MinimalLoopFinder::FindMinimalLoop(Graph* graph, Node* node) {
	Graph* result = graph->copyCoordinates();
	
	NodeExList list1;
	NodeExList list2;

	graphUsedFlag = graph->registerFlag();
	
	graph->setFlag(node, graphUsedFlag, false);
	list1.push_back(newNodeEx(node, NULL));

	bool b;
	do {
		b = nextStep(list1, list2, node, graph);
		list1 = list2;
	} while(b);

	if (list2.size() == 1) {
		NodeEx* nodeEx = *(list2.begin());

		//if there is 1 result -> it's loop
		if (nodeEx->node == node) {
			while (nodeEx->parent != NULL) {
				result->browseTo(nodeEx->node);
				nodeEx = nodeEx->parent;
			}
		} else ASSERT(false);
	}

	return result;
}



//todo: Implement node check for duplicates in lists not using set (can works too slow)
bool MinimalLoopFinder::nextStep(NodeExList& in, NodeExList& out, Node* root, Graph* graph) {
	out.clear();	
	for (NodeExList::iterator it = in.begin(); it != in.end(); it++) {
		NodeEx* nodeEx = *it;

		if (!graph->readFlag(nodeEx->node, graphUsedFlag)) {

			graph->setFlag(nodeEx->node, graphUsedFlag, true);

			GraphEdgeEnumerator ee(graph, nodeEx->node);
			Node* node;
			while (node = ee.nextTo()) {
				if (node == root) {
					out.clear();
					out.push_back(newNodeEx(node, nodeEx));
					return false;
				} else {
					out.push_back(newNodeEx(node, nodeEx));
				}		
			}
		}		
	}
	return true;
}


const int heapIncr = 1000;

void MinimalLoopFinder::InitHeap() {
	current = new NodeEx[heapIncr];
	last = &current[heapIncr];
	heap.push_back(current);
}

void MinimalLoopFinder::DisposeHeap() {
	for(NodeExs::iterator it = heap.begin(); it != heap.end(); it++) {
		delete[] *it;
	}
}

MinimalLoopFinder::NodeEx* MinimalLoopFinder::newNodeEx(Node* node, NodeEx* parent) {
	if (current == last) {
		InitHeap();
	}

	NodeEx* nodeEx = new(current++) NodeEx;
	nodeEx->node = node;
	nodeEx->parent = parent;

	return nodeEx;
}