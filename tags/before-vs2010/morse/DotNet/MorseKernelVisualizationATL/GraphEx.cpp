#include "StdAfx.h"
#include ".\graphex.h"

GraphEx::GraphEx(Graph* graph) : graph(graph)
{
	nodesInfo = new NodeInfo[graph->getNumberOfNodes()];
	newNodeInfo = nodesInfo;

	parseGraph();
}

GraphEx::~GraphEx(void)
{
	delete[] nodesInfo;
//	delete graph;
}


GraphEx::NodeInfo::NodeInfo() {
	minLoopLength = 0;
}

void GraphEx::parseGraph() {

	NodeEnumerator* ne = graph->getNodeRoot();
	Node* node;
	while (node = graph->getNode(ne)) {
			analizeQueue(graph, node);
	}
	graph->freeNodeEnumerator(ne);
}

GraphEx::NodeInfo* GraphEx::getNode(Node* node) {
	NodeInfo*& n = nodeMap[node];
	if (n == NULL) {
		n = newNodeInfo++;
	}
	return n;
}


void GraphEx::analizeQueue(Graph* graph, Node* base) {
	NodeInfo* nodeInfo = getNode(base);
	nodeInfo->minLoopLength = 1;

	WideSearchQueue queue;
	WideSearchQueue newQueue;

	queue.push_back(base);

	do {
		printf("Loop..\n");
		newQueue.clear();

		while (!queue.empty()) {
			Node* node = queue.front();
			queue.pop_front();

			EdgeEnumerator* ee = graph->getEdgeRoot(node);
			Edge* e;
			while (e = graph->getEdge(ee)) {
				printf("Edge...");
				Node* nodeTo = graph->getEdgeTo(e);

				if (nodeTo == base) {
					//min found!
					return;
				} else {
					newQueue.push_back(nodeTo);
				}
			}
			graph->freeEdgeEnumerator(ee);
		}
		nodeInfo->minLoopLength++;

		queue = newQueue;

		printf("\tNext Loop\n");
	} while (!newQueue.empty());
}


GraphEx::NodeInfo* GraphEx::operator [] (Node* node) {
	return nodeMap[node];
}

Graph* GraphEx::getGraph() {
	return graph;
}

GraphEx::operator Graph* () {
	return graph;
}


